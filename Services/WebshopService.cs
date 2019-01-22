using Data;
using Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class WebshopService : IWebshopService
    {
        private readonly ApplicationDbContext _DbContext;

        public WebshopService(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IEnumerable<WebshopItem> GetAll()
        {
            return _DbContext.WebshopItems;
        }

        public WebshopItem GetById(int id)
        {
            return GetAll().FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<WebshopItem> GetAllByCategory(string category)
        {
            return GetAll().Where(item => item.Category == category);
        }

        public void Add(WebshopItem item)
        {
            _DbContext.Add(item);
            _DbContext.SaveChanges();
        }

        public void Edit(WebshopItem item)
        {
            _DbContext.Update(item);
            _DbContext.SaveChanges();
        }

        public void Remove(WebshopItem item)
        {
            _DbContext.Remove(item);
            _DbContext.SaveChanges();
        }


        public int NumberOfItemsByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category)) { return GetAll().Count(); }
            return GetAllByCategory(category).Count();
        }
    }
}
