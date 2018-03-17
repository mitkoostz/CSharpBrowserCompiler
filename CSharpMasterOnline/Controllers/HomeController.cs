using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.IO;
using System.Reflection;
using System.Data.Entity;
using CSharpMasterOnline.DB;
using CSharpMasterOnline.DB.Tables;
using System.Data.Entity.Validation;

namespace CSharpMasterOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Compiler()
        {

            return View();
        }

        public ActionResult Challenges()
        {
            return View();
        }



        [WebMethod]
        public JsonResult Compile(string code)
        {

            //string codee = System.IO.File.ReadAllText(@"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\CSharpCodeProvider\code.txt");
            string programPath = @"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\CSharpCodeProvider\result.exe";
            var csc = new CSharpCodeProvider();
            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, programPath, true);
            parameters.GenerateExecutable = true;


            CompilerResults results = csc.CompileAssemblyFromSource(parameters, code);


            //Start app and get console output
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = programPath,
                    Arguments = "command line arguments to your executable",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            List<string> result = new List<string>();


            //proc.StandardInput.WriteLine("input");

                proc.StandardInput.Close();



                    while (!proc.StandardOutput.EndOfStream)
            {

                string line = proc.StandardOutput.ReadLine();
                result.Add(line);

            }


            var errors = results.Errors.Cast<CompilerError>().ToList();
            
            if(errors.Count != 0)
            {
                return Json(errors, JsonRequestBehavior.AllowGet);

            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }




    }
}