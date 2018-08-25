using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace RoseOrDaisyImageRecognitionApp.Controllers
{
    /// <summary>
    /// Image recognition REST api controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/image")]
    public class ImageRecognitionController : Controller
    {
        #region Methods

        /// <summary>
        /// Uploads the asynchronous.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns></returns>
        [HttpPost("upload")]
        public async Task<IActionResult> UploadAsync([FromForm]IFormFile image)
        {
            var output = "";
            // TODO: put file path to appsettings.json
            var filePath = "D:\\Faks\\DRC2sem\\RUAP\\Project\\Classification\\picture.jpg";

            if (image.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
            }
            output = await RunScriptAsync();
            var result = new RecognitionResult();
            result.Name = output;
            return Ok(result);
        }

        /// <summary>
        /// Runs the script asynchronous.
        /// </summary>
        /// <returns></returns>
        private async Task<string> RunScriptAsync()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = "/c py D:\\Faks\\DRC2sem\\RUAP\\Project\\Classification\\result.py";

            var process = new Process();
            process.StartInfo = psi;
            process.Start();
            string output = await process.StandardOutput.ReadToEndAsync();

            process.WaitForExit();
            return output;
        }

        #endregion Methods

        public class RecognitionResult
        {
            public string Name { get; set; }
        }
    }
}