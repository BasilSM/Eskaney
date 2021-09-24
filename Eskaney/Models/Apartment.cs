using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eskaney.Models
{
    //  شـقـة

    public class Apartment
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Required !!")]
        public int Floor_Number { get; set; } // رقم الطابق

        [Required(ErrorMessage = "Required !!")]
        public double Area { get; set; } // المساحة

        [Required(ErrorMessage = "Required !!")]
        public int Number_Of_Room { get; set; } // عدد الغرف

        [Required(ErrorMessage = "Required !!")]
        public int Number_Of_BathRoom { get; set; } // عدد الحمامات

        public double Price { get; set; }

        public int Phone { get; set; } 

        public string Notes { get; set; }

        public List<Picture> List_Of_Pictures { get; set; }

        

        [DisplayName("Housing")]
        [ForeignKey("housing")]
        public int Housing_ID { get; set; }
        public Housing housing { get; set; }


    }


    //public class Apartment
    //{
    //    public int ID { get; set; }

    //    [Required(ErrorMessage = "Required !!")]
    //    public int Floor_Number { get; set; } // رقم الطابق

    //    [Required(ErrorMessage = "Required !!")]
    //    public double Area { get; set; } // المساحة

    //    [Required(ErrorMessage = "Required !!")]
    //    public int Number_Of_Room { get; set; } // عدد الغرف

    //    [Required(ErrorMessage = "Required !!")]
    //    public int Number_Of_BathRoom { get; set; } // عدد الحمامات


    //    public string Notes { get; set; }



    //    [DisplayName("Housing")]
    //    [ForeignKey("housing")]
    //    public int Housing_ID { get; set; }
    //    public Housing housing { get; set; }
    //}
}