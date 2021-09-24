using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eskaney.Models
{
    public class Picture
    {
        public int ID { get; set; }
        public string Url { get; set; }


        [DisplayName("Apartment")]
        [ForeignKey("apartment")]
        public int Apartment_ID { get; set; }
        public Apartment apartment { get; set; }


    }
}