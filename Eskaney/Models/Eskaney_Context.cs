using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eskaney.Models
{

    public class Eskaney_Context : DbContext
    {
        public Eskaney_Context() : base("name=Eskaneydb") { }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Housing> Housings { get; set; }
        public virtual DbSet<ManPowerCoust> ManPowerCousts { get; set; }
        public virtual DbSet<Material_Expenses> Material_Expenses { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
    }


    //public class Eskaney_Context : DbContext
    //{
    //    public Eskaney_Context() : base("name=Eskaney") { }

    //    public virtual DbSet<Apartment> Apartments { get; set; }
    //    public virtual DbSet<City> Cities { get; set; }
    //    public virtual DbSet<Country> Countries { get; set; }
    //    public virtual DbSet<Housing> Housings { get; set; }
    //    public virtual DbSet<Labour_Wages> Labour_Wages { get; set; }
    //    public virtual DbSet<Material_Expenses> Material_Expenses { get; set; }

    //}
}