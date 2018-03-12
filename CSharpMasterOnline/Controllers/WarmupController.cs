using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpMasterOnline.Controllers
{
    public class WarmupController : Controller
    {
        // GET: Warmup
        [Route("Warmup")]
        public ActionResult Index()
        {

            return View();
        }

        [Route("Warmup/{exerciseName}/{exerciseId}")]
        public ActionResult Exercise(string exerciseId)
        {


            return View();
        }
    }
}