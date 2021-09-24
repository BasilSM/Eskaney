using Eskaney.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Eskaney.Areas.Apartments.Controllers
{
    public class ApartmentsController : Controller
    {
        private Eskaney_Context db = new Eskaney_Context();

        // GET: Apartments/Apartments
        public ActionResult Home()
        {
            ViewModel VM = new ViewModel();
            VM.List_Of_Apartments = db.Apartments.ToList();

            VM.List_Of_Housings = db.Housings.ToList();

            List<Company> companies = db.Companies.ToList();

            List<Apartment> apartments = db.Apartments.ToList();

            List<Housing> housings = db.Housings.ToList();

            List<City> cityName = db.Cities.ToList();

            List<Picture> pictures = db.Pictures.ToList();


            var MM = from A in apartments
                     join h in housings on A.Housing_ID equals h.ID into table1
                     from h in table1.DefaultIfEmpty()
                     join c in cityName on h.City_ID equals c.ID into table2
                     from c in table2.DefaultIfEmpty()


                     select new ViewModel { City = c, Apartment = A, Housing = h };
            
            return View(MM);
            //return View(VM);
        }

        [HttpGet]
        public ActionResult FillApartments()
        {
            List<Apartment> apartments = db.Apartments.ToList();
            return Json(apartments, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public /*string*/ActionResult GetCity(int id)
        {

            var city = (from a in db.Housings
                            //join b in db.Cities on a.City_ID equals b.ID
                        where a.ID == id
                        select new
                        {
                            ID = a.City_ID,
                            Name = a.city.Name,
                            Location = a.Location
                        }).FirstOrDefault();

            return Json(city, JsonRequestBehavior.AllowGet);
            //return city.ToString();

        }



        public ActionResult Add_Apart(int id)
        {
            if (Session["Company"] != null)
            {
                var Ap = db.Apartments.Where(a => a.Housing_ID == id).ToList().FirstOrDefault();
                Ap.Housing_ID = id;
                TempData["HousingID"] = id;
                ViewBag.ID = id;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        [HttpPost]
        public ActionResult Add_Apart(int id, Apartment apartment)
        {
            if (Session["Company"] != null)
            {
                if (ModelState.IsValid)
                {
                    apartment.Housing_ID = id;
                    db.Apartments.Add(apartment);
                    db.SaveChanges();
                    return RedirectToAction("My_Ads", new { @id = apartment.Housing_ID });
                }

                apartment.Housing_ID = id;
                TempData["HousingID"] = id;
                ViewBag.ID = id;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        public ActionResult My_Ads(int? id)
        {
            List<Apartment> apartments = db.Apartments.Where(a => a.Housing_ID == id).ToList();
            var aa = db.Pictures.Where(a => a.Apartment_ID == id).FirstOrDefault();
            //ViewBag.Logo = aa.Url;
            //TempData["Pic"] = aa.Url;
            TempData["HousingID"] = id;
            ViewBag.ID = id;
            return View(apartments);
        }

    }
}