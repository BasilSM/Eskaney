using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Eskaney.Models;
using Microsoft.Ajax.Utilities;

namespace Eskaney.Areas.Housing_Projects.Controllers
{
    public class ManPowerController : Controller
    {
        private Eskaney_Context db = new Eskaney_Context();

        // GET: Housing_Projects/ManPower/Create
        public ActionResult Add_ManPower(int? id)
        {
            if (Session["Company"] != null)
            {
                var aa = db.Housings.Where(a => a.ID == id).ToList().FirstOrDefault();
                TempData["HousingID"] = aa.ID;
                TempData["ProjectName"] = aa.Project_Name;
                TempData["Logo"] = aa.Logo;
                var x = aa.Company_ID;


                var com = db.Companies.Where(a => a.ID == x).FirstOrDefault();
                TempData["CompanyName"] = com.Name;
                ViewBag.Logo = aa.Logo;
                ViewBag.ID = aa.ID;

                

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }



        // GET: Housing_Projects/ManPower/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Company"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ManPowerCoust manPowerCoust = db.ManPowerCousts.Find(id);
                if (manPowerCoust == null)
                {
                    return HttpNotFound();
                }
                return View(manPowerCoust);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }

        }

        // GET: Housing_Projects/ManPower
        public ActionResult ManPower_Details(int? id)
        {

            if (Session["Company"] != null)
            {
                var aa = db.Housings.Where(a => a.ID == id).ToList().FirstOrDefault();
                TempData["HousingID"] = aa.ID;
                TempData["ProjectName"] = aa.Project_Name;
                TempData["Logo"] = aa.Logo;
                var x = aa.Company_ID;


                var com = db.Companies.Where(a => a.ID == x).FirstOrDefault();
                TempData["CompanyName"] = com.Name;
                ViewBag.Logo = aa.Logo;
                ViewBag.ID = aa.ID;

                var manPowerCousts = db.ManPowerCousts.Where(c => c.Housing_ID == id).Include(m => m.housing);

                return View(manPowerCousts.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }

        }




        // POST: Housing_Projects/ManPower/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_ManPower(/*[Bind(Include = "ID,Parson_Name,Labour_Name,Parson_Phone,Date,Coust,Payment_Vaucher,Notes,Housing_ID")]*/ int id, ManPowerCoust manPowerCoust)
        {
            if (Session["Company"] != null)
            {
                if (ModelState.IsValid)
                {
                    manPowerCoust.Housing_ID = id;
                    db.ManPowerCousts.Add(manPowerCoust);
                    db.SaveChanges();
                    return RedirectToAction("ManPower_Details", new { @id = manPowerCoust.Housing_ID });
                }

                manPowerCoust.Housing_ID = id;
                TempData["HousingID"] = id;
                ViewBag.ID = id;
                return View(manPowerCoust);


            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
            
        }



        // GET: Housing_Projects/ManPower/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Company"] != null)
            {
                var aa = db.ManPowerCousts.Where(a => a.ID == id).ToList().FirstOrDefault();
                TempData["HousingID"] = aa.Housing_ID;

                var bb = db.Housings.Where(a => a.ID == aa.Housing_ID).ToList().FirstOrDefault();

                TempData["ProjectName"] = bb.Project_Name;
                TempData["Logo"] = bb.Logo;

                ViewBag.Logo = bb.Logo;
                ViewBag.ID = bb.ID;

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ManPowerCoust manPowerCoust = db.ManPowerCousts.Find(id);
                if (manPowerCoust == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Housing_ID = manPowerCoust.Housing_ID;
                //ViewBag.Housing_ID = new SelectList(db.Housings, "ID", "Project_Name", manPowerCoust.Housing_ID);
                return View(manPowerCoust);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }

        }

        // POST: Housing_Projects/ManPower/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "ID,Parson_Name,Labour_Name,Parson_Phone,Date,Coust,Payment_Vaucher,Notes,Housing_ID")]*/ int id, ManPowerCoust manPowerCoust)
        {
            if (Session["Company"] != null)
            {
                var manPower = db.ManPowerCousts.AsNoTracking().Where(a => a.ID == id).ToList().FirstOrDefault();
                var Housing_ID = manPower.Housing_ID;
                TempData["HousingID"] = Housing_ID;

                if (ModelState.IsValid)
                {
                    manPowerCoust.Housing_ID = Housing_ID;
                    db.Entry(manPowerCoust).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ManPower_Details", new { @id = manPowerCoust.Housing_ID });
                }

                ViewBag.Housing_ID = manPowerCoust.Housing_ID;
                return View(manPowerCoust);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            } 
        }

        // GET: Housing_Projects/ManPower/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Company"] != null)
            {
                var ManPow = db.ManPowerCousts.AsNoTracking().Where(a => a.ID == id).ToList().FirstOrDefault();
                var Housing_ID = ManPow.Housing_ID;
                TempData["HousingID"] = Housing_ID;



                var bb = db.Housings.Where(a => a.ID == Housing_ID).ToList().FirstOrDefault();

                TempData["ProjectName"] = bb.Project_Name;
                TempData["Logo"] = bb.Logo;

                ViewBag.Logo = bb.Logo;
                ViewBag.ID = bb.ID;

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ManPowerCoust manPowerCoust = db.ManPowerCousts.Find(id);
                if (manPowerCoust == null)
                {
                    return HttpNotFound();
                }
                return View(manPowerCoust);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }

        }

        // POST: Housing_Projects/ManPower/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (Session["Company"] != null)
            {
                ManPowerCoust manPowerCoust = db.ManPowerCousts.Find(id);
                db.ManPowerCousts.Remove(manPowerCoust);
                db.SaveChanges();
                return RedirectToAction("ManPower_Details", new { @id = manPowerCoust.Housing_ID });
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
