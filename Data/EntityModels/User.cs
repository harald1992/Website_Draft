using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EntityModels
{
    public class User
    {
        // Zijn Entity / Domain models, deze mappen direct naar Database tabellen.
        //Deze models zijn dus anders dan in de Presentation layer.

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}
