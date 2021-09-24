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
    //  اسـكـان

    public class Housing
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Required !!")]
        public string Project_Name { get; set; }

        [Required(ErrorMessage = "Required !!")]
        public int Piece_Number { get; set; } // رقم القطعة

        [Required(ErrorMessage = "Required !!")]
        public string Location { get; set; }


        [DataType(DataType.Date)]
        [LisDate] /* ماحطينا الايرور مسج لانو معرفينها داخل الكلاس */
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required !!")]
        public int Basin_Number { get; set; }  //  رقم الحوض

        [Required(ErrorMessage = "Required !!")]
        public double Land_Area { get; set; }  // مساحة الارض

        [Required(ErrorMessage = "Required !!")]
        public double Building_Area { get; set; }  // مساحة البناء

        [Required(ErrorMessage = "Required !!")]
        public double Apartments_Total_Area { get; set; } // مساحة الشقق كاملة

        [Required(ErrorMessage = "Required !!")]
        public double Sarvisas_Total_Area { get; set; } // مساحة الخدمات

        [Required(ErrorMessage = "Required !!")]
        public int Number_Of_Floors { get; set; }  // عدد الطوابق

        [Required(ErrorMessage = "Required !!")]
        public int Number_Of_Apartment { get; set; }  // عدد الشقق

        [Required(ErrorMessage = "Required !!")]
        public double Land_Price { get; set; }  // سعر الارض

        [Required(ErrorMessage = "Required !!")]
        public double Land_Registration { get; set; }  // تسجيل الارض

        [Required(ErrorMessage = "Required !!")]
        public double Building_Licence { get; set; } // رخصة البناء

        [Required(ErrorMessage = "Required !!")]
        public double DesignAndEngineering { get; set; } // التصميم والهندسة

        [Required(ErrorMessage = "Required !!")]
        public double Supervision { get; set; } // الاشراف

        public string Logo { get; set; }

        public string Notes { get; set; }



        public List<Apartment> List_Of_Apartments { get; set; }


        public List<ManPowerCoust> List_Of_ManPowerCousts { get; set; }


        public List<Material_Expenses> List_Of_Material_Expenses { get; set; }



        [DisplayName("Country")]
        [ForeignKey("country")]
        public int Country_ID { get; set; }
        public Country country { get; set; }

        [DisplayName("City")]
        [ForeignKey("city")]
        public int City_ID { get; set; }
        public City city { get; set; }

        [DisplayName("Company")]
        [ForeignKey("company")]
        public int Company_ID { get; set; }
        public Company company { get; set; }
    }

    //public class Housing
    //{
    //    public int ID { get; set; }

    //    [Required(ErrorMessage = "Required !!")]
    //    public string Project_Name { get; set; }

    //    [Required(ErrorMessage = "Required !!")]
    //    public int Piece_Number { get; set; } // رقم القطعة

    //    [Required(ErrorMessage = "Required !!")]
    //    public string Location { get; set; }

    //    [Required(ErrorMessage = "Required !!")]
    //    public DateTime Date { get; set; }

    //    [Required(ErrorMessage = "Required !!")]
    //    public int Basin_Number { get; set; } //  رقم الحوض

    //    [Required(ErrorMessage = "Required !!")]
    //    public double Land_Area { get; set; } // مساحة الارض

    //    [Required(ErrorMessage = "Required !!")]
    //    public double Building_Area { get; set; } // مساحة البناء

    //    [Required(ErrorMessage = "Required !!")]
    //    public int Number_Of_Floors { get; set; } // عدد الطوابق

    //    [Required(ErrorMessage = "Required !!")]
    //    public int Number_Of_Apartment { get; set; } // عدد الشقق

    //    [Required(ErrorMessage = "Required !!")]
    //    public double Land_Price { get; set; } // سعر الارض

    //    [Required(ErrorMessage = "Required !!")]
    //    public double Registration_Coast { get; set; } // تكاليف التسجيل والترخيص

    //    public string Notes { get; set; }



    //    public List<Apartment> List_Of_Apartments { get; set; }


    //    public List<Labour_Wages> List_Of_Labour_Wages { get; set; }


    //    public List<Material_Expenses> List_Of_Material_Expenses { get; set; }




    //    [DisplayName("Country")]
    //    [ForeignKey("country")]
    //    public int Country_ID { get; set; }
    //    public Country country { get; set; }

    //    [DisplayName("City")]
    //    [ForeignKey("city")]
    //    public int City_ID { get; set; }
    //    public City city { get; set; }
    //}
}