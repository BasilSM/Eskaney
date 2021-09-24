using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eskaney.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DisplayName("Country")]
        [ForeignKey("country")]
        public int Country_ID { get; set; }
        public Country country { get; set; }

        public List<Housing> Housings_List { get; set; }
    }
}