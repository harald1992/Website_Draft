using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.EntityModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class WebshopController : Controller
    {
        private readonly IWebshopService _WebshopService;
        private readonly IHostingEnvironment _HostingEnvironment;

        public int DatabaseCount;
        public int DatabaseCount_Badminton;

        public WebshopController(IWebshopService webshopService, IHostingEnvironment hostingEnvironment)
        {
            _WebshopService = webshopService;
            _HostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index(string category)
        {
            IEnumerable<WebshopItem> WebshopList;

            //indien geen zoekcriteria de hele lijst, anders gefilterd.
            if (string.IsNullOrWhiteSpace(category))
            {
                WebshopList = _WebshopService.GetAll();
            }
            else
            {
                WebshopList = _WebshopService.GetAllByCategory(category);
            }

            var ListingResult = WebshopList.Select(result => new WebshopItemViewmodel
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                Category = result.Category

            });

            var model = new WebshopItemViewmodelList()
            {
                WebshopItems = ListingResult,
                DatabaseCount = _WebshopService.NumberOfItemsByCategory(""),
                DatabaseCount_Badminton = _WebshopService.NumberOfItemsByCategory("Badminton")
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(string name, string description, string category, decimal price)
        {
            WebshopItem item = new WebshopItem
            {
                Name = name,
                Description = description,
                Category = category,
                Price = price
            };

            _WebshopService.Add(item);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _WebshopService.GetById(id);
            _WebshopService.Remove(item);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id, string name, string description, string category, decimal price)
        {
            WebshopItem item = _WebshopService.GetById(id);
            item.Name = name;
            item.Description = description;
            item.Category = category;
            item.Price = price;

            _WebshopService.Edit(item);
            return RedirectToAction("Index");
        }

    }
}