using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModels
{
    public class WebshopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

}
