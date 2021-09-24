using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eskaney.Models
{

    public class ViewModel
    {
        public Company Company { get; set; }
        public List<Company> List_OF_Companies { get; set; }
        public Housing Housing { get; set; }
        public List<Housing> List_Of_Housings { get; set; }
        public ManPowerCoust ManPowerCoust { get; set; }
        public List<ManPowerCoust> List_Of_ManPowerCousts { get; set; }
        public Apartment Apartment { get; set; }
        public List<Apartment> List_Of_Apartments { get; set; }
        public Material_Expenses Material_Expenses { get; set; }
        public List<Material_Expenses> List_Of_Material_Expenses { get; set; }
        public List<Country> List_Of_Countries { get; set; }
        public City City { get; set; }
        public List<City> List_Of_Cities { get; set; }
        public Picture Picture { get; set; }
        public List<Picture> List_Of_Pictures { get; set; }

        public Material Material { get; set; }
        public List<Material> List_Of_Materials { get; set; }

    }


    //public class ViewModel
    //{
    //    public Housing Housing { get; set; }
    //    public List<Housing> List_Of_Housings { get; set; }
    //    public Labour_Wages Labour_Wages { get; set; }
    //    public List<Labour_Wages> List_Of_Labour_Wages { get; set; }
    //    public Apartment Apartment { get; set; }
    //    public List<Apartment> List_Of_Apartments { get; set; }
    //    public Material_Expenses Material_Expenses { get; set; }
    //    public List<Material_Expenses> List_Of_Material_Expenses { get; set; }
    //    public List<Country> List_Of_Countries { get; set; }
    //    public List<City> List_Of_Cities { get; set; }


    //}
}