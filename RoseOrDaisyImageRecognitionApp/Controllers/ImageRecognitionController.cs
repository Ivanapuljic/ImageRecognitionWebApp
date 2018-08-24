using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RoseOrDaisyImageRecognitionApp.Controllers
{
    [Route("api/image")]
    public class ImageRecognitionController : Controller
    {
        #region Methods

        [HttpGet("test-2")]
        public async Task<IActionResult> Test2Async()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = "/c py D:\\Faks\\DRC2sem\\RUAP\\Project\\RoseOrDaisyImageRecognitionApp\\Data\\test.py";

            var process = new Process();
            process.StartInfo = psi;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            return Ok(output);
        }

        [HttpGet("test")]
        public async Task<IActionResult> TestAsync()
        {
            var x = await RunScript();
            return Ok(x);
        }

        private async Task<List<string>> RunScript()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "py D:\\Moje\\RoseOrDaisyImageRecognitionApp\\RoseOrDaisyImageRecognitionApp\\Data\\test.py";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            var output = new List<string>();

            while (process.StandardOutput.Peek() > -1)
            {
                output.Add(process.StandardOutput.ReadLine());
            }

            while (process.StandardError.Peek() > -1)
            {
                output.Add(process.StandardError.ReadLine());
            }
            process.WaitForExit();
            return output;
        }

        #endregion Methods
    }
}