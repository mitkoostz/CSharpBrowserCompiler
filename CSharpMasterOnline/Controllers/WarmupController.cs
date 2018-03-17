using CSharpMasterOnline.DB;
using CSharpMasterOnline.DB.Tables;
using CSharpMasterOnline.Models;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace CSharpMasterOnline.Controllers
{
    public class WarmupController : Controller
    {
        // GET: Warmup
        [Route("Warmup")]
        public ActionResult Index()
        {
           
            using (var db = new DataContext())
            {
                var warmupChallenges = db.Challenges.Where(ch => ch.Section == "Warmup").ToList();

                return View(warmupChallenges);

            }
        }

        [Route("Warmup/{challengeName}/{challengeId}")]
        public ActionResult Challenge(string challengeId , string challengeName)
        {
            using (var db = new DataContext())
            {
                Challenge challenge = db.Challenges.Find(challengeId);

                var result =  (ChallengeTransport)TransferHelper.ChallengeTransport(challenge);
          

                return View(result);

            }

        }


        [WebMethod]
        public string SubmitResult(string challengeId, string code, string challengeName)
        {

            string programPath = @"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\CSharpCodeProvider\" + challengeName + ".exe";
            var csc = new CSharpCodeProvider();
            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, programPath, true);
            parameters.GenerateExecutable = true;

            CompilerResults results = csc.CompileAssemblyFromSource(parameters, code);

            string[] input;
            string[] input2;
            string[] output;
            string[] output2;
            bool test1 = false;
            bool test2 = false;
            bool IsCompilatioonError = false;

            using (var db = new DataContext())
            {
                var challenge = db.Challenges.Find(challengeId);
                input = System.IO.File.ReadAllLines(challenge.SampleInput);
                input2 = System.IO.File.ReadAllLines(challenge.SampleInput2);
                output = System.IO.File.ReadAllLines(challenge.SampleOutput);
                output2 = System.IO.File.ReadAllLines(challenge.SampleOutput2);

            }


            try
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = programPath,
                        Arguments = "command line arguments to your executable",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                        CreateNoWindow = true,


                    }
                };
                proc.Start();

                for (int i = 0; i < input.Length; i++)
                {
                    proc.StandardInput.WriteLine(input[i]);

                }
                 

                List<string> result = new List<string>();
                while (!proc.StandardOutput.EndOfStream)
                {

                    string line = proc.StandardOutput.ReadLine();
                    result.Add(line);

                }
                for (int i = 0; i < output.Length; i++)
                {
                    if (output[i] == result[i])
                    {
                        test1 = true;
                    }
                    else
                    {
                        test1 = false;
                        break;
                    }
                }
                var errors = results.Errors.Cast<CompilerError>().ToList();
                if (errors.Count != 0) { IsCompilatioonError = true; }

                var isex = proc.HasExited;
                proc.WaitForExit();
                proc.Start();

                for (int i = 0; i < input2.Length; i++)
                {
                    proc.StandardInput.WriteLine(input2[i]);

                }


                List<string> result2 = new List<string>();
                while (!proc.StandardOutput.EndOfStream)
                {

                    string line = proc.StandardOutput.ReadLine();
                    result2.Add(line);

                }

                for (int i = 0; i < output2.Length; i++)
                {
                    if (output2[i] == result2[i])
                    {
                        test2 = true;
                    }
                    else
                    {
                        test2 = false;
                        break;
                    }
                }

                var errors2 = results.Errors.Cast<CompilerError>().ToList();
                if (errors2.Count != 0) { IsCompilatioonError = true; }

                if (IsCompilatioonError) { return "Compilation Error!"; }
                if (test1 == false || test2 == false) { return "Wrong Answer!"; }


                return "Challenge Completed!";
            }
            catch (Exception)
            {
                return "Compilation Error!";
                
            }
           
        }






    }
}