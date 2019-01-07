using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Website_Draft.Controllers
{
    public class CvBuilderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}