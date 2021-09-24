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
    // تكاليف المواد


    public class Material_Expenses
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Required !!")]
        public string Material_Name { get; set; } //  اسم المادة

        [Required(ErrorMessage = "Required !!")]
        public string Material_Source { get; set; } // المصدر

        [Required(ErrorMessage = "Required !!")]
        public double Quantity { get; set; } // الكمية

        [Required(ErrorMessage = "Required !!")]
        [DataType(DataType.Date)]
        [LisDate]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required !!")]
        public double Coust { get; set; } // التكلفة

        [Required(ErrorMessage = "Required !!")]
        public string EnvoiceNumber { get; set; } // رقم الفاتورة

        public string Notes { get; set; }



        [DisplayName("Housing")]
        [ForeignKey("housing")]
        public int Housing_ID { get; set; }
        public Housing housing { get; set; }
    }


    //public class Material_Expenses
    //{
    //    public int ID { get; set; }

    //    [Required(ErrorMessage = "Required !!")]
    //    public string Material_Name { get; set; } //  اسم المادة

    //    [Required(ErrorMessage = "Required !!")]
    //    public string Material_Exporter { get; set; } // المصدر

    //    [Required(ErrorMessage = "Required !!")]
    //    public double Quantity { get; set; } // الكمية

    //    [Required(ErrorMessage = "Required !!")]
    //    public DateTime Date { get; set; }

    //    [Required(ErrorMessage = "Required !!")]
    //    public double Coust { get; set; } // التكلفة


    //    public string Notes { get; set; }



    //    [DisplayName("Housing")]
    //    [ForeignKey("housing")]
    //    public int Housing_ID { get; set; }
    //    public Housing housing { get; set; }
    //}
}