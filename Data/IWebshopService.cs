using Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IWebshopService
    {
        IEnumerable<WebshopItem> GetAll();

        IEnumerable<WebshopItem> GetAllByCategory(string category);

        int NumberOfItemsByCategory(string category);

        WebshopItem GetById(int id);

        void Add(WebshopItem item);

        void Edit(WebshopItem item);

        void Remove(WebshopItem item);


    }
}
