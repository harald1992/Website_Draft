using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        private IUserService _Users;

        public AdminController(IUserService users)
        {
            _Users = users;
        }

        public IActionResult Index()
        {
            var userList = _Users.GetAll();

            var listingResult = userList.Select(result => new UserListingModel
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

        [HttpPost]
        public IActionResult Create(string name)
        {
            User newUser = new User
            {
                Name = name,
                IsAdmin = false
            };

            _Users.Add(newUser);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            User userToDelete = _Users.GetById(id);
            _Users.Remove(userToDelete);
            return RedirectToAction("Index");
        }

    }
}
