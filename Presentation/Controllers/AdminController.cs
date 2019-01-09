using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        private IUser _Users;

        public AdminController(IUser users)
        {
            _Users = users;
        }

        public IActionResult Index()
        {
            var users = _Users.GetAll();

            var listingResult = users.Select(result => new UserListingModel
            {
                Id = result.Id,
                Name = result.Name,
                IsAdmin = result.IsAdmin
            });

            var model = new UserList()
            {
                Users = listingResult
            };
            
            return View(model);
        }

        [HttpGet]
        public UserListingModel Create(string name)
        {
            return new UserListingModel { Name = name };
        }

    }
}
