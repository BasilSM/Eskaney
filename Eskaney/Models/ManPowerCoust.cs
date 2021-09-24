using Eskaney.CoustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eskaney.Models
{
    //  مصاريف العمل

    public class ManPowerCoust
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Required!!")]
        public string Parson_Name { get; set; } // اسم الشخص

        [Required(ErrorMessage = "Required!!")]
        public string Labour_Name { get; set; } // اسم العمل

        [Required(ErrorMessage = "Required!!")]
        public int Parson_Phone { get; set; }   // رقم الهاتف

        [Required(ErrorMessage = "Required!!")]
        [DataType(DataType.Date)]
        [LisDate]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required!!")]
        public double Coust { get; set; }

        public int Payment_Vaucher { get; set; } // رقم سند الصرف

        public string Notes { get; set; }



        [DisplayName("Housing")]
        [ForeignKey("housing")]
        public int Housing_ID { get; set; }
        public Housing housing { get; set; }
    }


    //public class Labour_Wages
    //{
    //    public int ID { get; set; }

    //    [Required(ErrorMessage = "Required!!")]
    //    public string Parson_Name { get; set; } // اسم الشخص

    //    [Required(ErrorMessage = "Required!!")]
    //    public string Labour_Name { get; set; } // اسم العمل

    //    [Required(ErrorMessage = "Required!!")]
    //    public int Parson_Phone { get; set; }   // رقم الهاتف

    //    [DataType(DataType.Date)]
    //    public DateTime Date { get; set; }

    //    [Required(ErrorMessage = "Required!!")]
    //    public double Coust { get; set; }

    //    public string Notes { get; set; }



    //    [DisplayName("Housing")]
    //    [ForeignKey("housing")]
    //    public int Housing_ID { get; set; }
    //    public Housing housing { get; set; }
    //}
}