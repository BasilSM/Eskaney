using Eskaney.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Eskaney.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        private readonly Eskaney_Context _Context;

        public HomeController()
        {
            _Context = new Eskaney_Context();
        }

        private Eskaney_Context db = new Eskaney_Context();


        // GET: Home/Home
        [HttpGet]
        public ActionResult Home()
        {

            Session["Admin"] = null;
            Session["Company"] = null;

            return View();
        }


        public ActionResult Test()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            Session["Admin"] = null;
            Session["Company"] = null;
            return View();
        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            Session["Company"] = null;
            return RedirectToAction("Home", "Home", new { area = "Home"});
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Password")]Company company)
        {
            var rec = db.Companies.Where(a => a.Email == company.Email && a.Password == company.Password).ToList().FirstOrDefault();

            if (rec != null)
            {
                if (rec.Name == "Basil")
                {
                    Session["Admin"] = rec.Name;
                    Session["AdminLogo"] = rec.Logo;
                    return RedirectToAction("AdminHome", "Companies", new { area = "Admin_Page" });
                }
                else
                {
                    Session["Company"] = rec.Name;
                    TempData["Logo"] = rec.Logo;
                    return RedirectToAction("Chose_Project", "Housings", new { area = "Housing_Projects", id = rec.ID });
                }
            }
            else
            {
                ViewBag.Error = "Invalid User";
                return View(company);
            }
        }






        public ActionResult Test2()
        {
            TempData["ID"] = 1;
            return View();
        }

        public List<Housing> FillHousings(int id)
        {
            List<Housing> housings = db.Housings.Where(a => a.Company_ID == id).Include(h => h.city).Include(h => h.company).Include(h => h.country).ToList();
            return housings;
        }

        public ActionResult Meterial_Details(int id)
        {
            var rec = db.Housings.Where(a => a.ID == id).ToList().FirstOrDefault();

            TempData["ID"] = rec.ID;
            TempData["ProjectName"] = rec.Project_Name;
            TempData["Logo"] = rec.Logo;

            ViewBag.Logo = rec.Logo;
            ViewBag.ID = rec.ID;
            return View();
        }

        public JsonResult getMaterials(int id)
        {
            ViewData["ID"] = id;
            var Material = db.Material_Expenses.Where(a => a.Housing_ID == id).ToList();
            return Json(Material, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Test3()
        {
            List<Housing> housings = _Context.Housings.ToList();
            return View(housings);
        }

        public ActionResult Test4()
        {
            Session["Test"] = "Test";
            return View();
        }

    }
}