using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eskaney.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<City> List_Of_City { get; set; }

        public List<Housing> Housings_List { get; set; }
    }
}