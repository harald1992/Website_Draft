using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website_Draft.Models;

namespace Website_Draft.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Admin Create(string name)
        {
            return new Admin { Name = name };
        }

    }
}
