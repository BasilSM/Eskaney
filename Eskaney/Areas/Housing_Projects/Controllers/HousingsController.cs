using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Schema;
using Eskaney.Models;

namespace Eskaney.Areas.Housing_Projects.Controllers
{
    public class HousingsController : Controller
    {
        private Eskaney_Context db = new Eskaney_Context();

        // GET: Housing/Housings
        [HttpGet]
        public ActionResult Chose_Project(int? id)
        {
            if (Session["Company"] != null)
            {
                var rec = db.Companies.Where(a => a.ID == id).ToList().FirstOrDefault();
                ViewModel vm = new ViewModel();
                TempData["CompanyID"] = rec.ID;
                TempData["CompanyName"] = rec.Name;
                TempData["Logo"] = rec.Logo;
                //vm.List_Of_Housings = new List<Housing>();
                //var housings = db.Housings.Include(h => h.city).Include(h => h.company).Include(h => h.country);
                //return View(housings.ToList());
                //var housing = db.Housings.Where(h => h.ID == id).ToList().FirstOrDefault();
                vm.List_Of_Housings = FillHousings(id);
                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        public List<Housing> FillHousings(int? id)
        {
            List<Housing> housings = db.Housings.Where(a => a.Company_ID == id).Include(h => h.city).Include(h => h.company).Include(h => h.country).ToList();
            return housings;
        }

        public ActionResult Home_Page(int? id)
        {
            if (Session["Company"] != null)
            {
                var rec = db.Housings.Where(a => a.ID == id).ToList().FirstOrDefault();

                TempData["CompanyID"] = rec.Company_ID;

                TempData["HousingID"] = rec.ID;
                ViewBag.ID = rec.ID;

                TempData["ProjectName"] = rec.Project_Name;
                TempData["Logo"] = rec.Logo;

                ViewBag.Logo = rec.Logo;
                var comp = rec.Company_ID;

                var com = db.Companies.Where(a => a.ID == comp).FirstOrDefault();

                TempData["CompanyName"] = com.Name;

                ViewModel VM = new ViewModel();
                
                VM.List_Of_ManPowerCousts = db.ManPowerCousts.Where(q => q.Housing_ID == id).ToList();
                VM.List_Of_Material_Expenses = db.Material_Expenses.Where(a => a.Housing_ID == id).ToList();
               
                return View(VM);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        [HttpGet]
        public JsonResult FillManPowerInfo()
        {
            //var manPowerCousts = db.ManPowerCousts.Select(a => new {

            //    PName = a.Parson_Name,
            //    LName = a.Labour_Name,
            //    Phone = a.Parson_Phone
            //}).ToList();

            //List<ManPowerCoust> manPowerCousts = db.ManPowerCousts.ToList();
            //return Json(manPowerCousts, JsonRequestBehavior.AllowGet);

            var manPowerCousts = db.ManPowerCousts.GroupBy(a => new { a.Parson_Name , a.Labour_Name, a.Parson_Phone}).Select(a=> a.Key).ToList();
            
            return Json(manPowerCousts.ToList(), JsonRequestBehavior.AllowGet);
        }
        


        //List<ManPowerCoust> manPowerCousts = db.ManPowerCousts.Select(x => new {
        //    PName = x.Parson_Name,
        //    LName = x.Labour_Name
        //})
        //            .Distinct();
        // GET: Admin_Page/Admin
        [HttpGet]
        public ActionResult FillHome_Page(int id)
        {
            List<Housing> housings = db.Housings.Where(a => a.ID == id).ToList();

            return Json(housings, JsonRequestBehavior.AllowGet);
        }


        // GET: Housing/Housings/Housing_Info
        [HttpGet]
        public ActionResult Housing_Info(int? id)
        {
            if (Session["Company"] != null)
            {
                var rec = db.Housings.Where(a => a.ID == id).ToList().FirstOrDefault();

                TempData["CompanyID"] = rec.Company_ID;

                TempData["Name"] = rec.Project_Name;
                TempData["HousingID"] = rec.ID;


                

                var com = db.Companies.Where(a => a.ID == rec.Company_ID).FirstOrDefault();
                TempData["CompanyName"] = com.Name;
                ViewBag.Logo = rec.Logo;
                ViewBag.ID = rec.ID;


                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        [HttpGet]
        public ActionResult FillHousing_Info(int id)
        {
            if (Session["Company"] != null)
            {
                List<Housing> housings = db.Housings.Where(a => a.ID == id).ToList();
                return Json(housings, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }


        // GET: Housing/Housings/Housing_Info
        [HttpGet]
        public ActionResult Costs_Info(int? id)
        {
            if (Session["Company"] != null)
            {
                var rec = db.Housings.Where(a => a.ID == id).ToList().FirstOrDefault();

                TempData["CompanyID"] = rec.Company_ID;

                TempData["Name"] = rec.Project_Name;
                TempData["HousingID"] = rec.ID;

                var com = db.Companies.Where(a => a.ID == rec.Company_ID).FirstOrDefault();
                TempData["CompanyName"] = com.Name;
                ViewBag.Logo = rec.Logo;
                ViewBag.ID = rec.ID;



                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ViewModel VM = new ViewModel();

                // Total Expenses For ManPower  مجموع مصاريف العمال للمشروع    /*  .Sum(a => (double?)a.Coust) ?? 0 بخلي قيمتها 0 في حالة ماكان في داتا */
                double TotalExpensesForManPower = db.ManPowerCousts.Where(a => a.Housing_ID == id).Sum(a => (double?)a.Coust)?? 0;
                ViewBag.TotalExpForManPower = TotalExpensesForManPower;



                // Total Expenses For Material  مجموع مصاريف المواد للمشروع    /*  .Sum(a => (double?)a.Coust) ?? 0 بخلي قيمتها 0 في حالة ماكان في داتا */
                double TotalExpensesForMaterial = db.Material_Expenses.Where(a => a.Housing_ID == id).Sum(a => (double?)a.Coust) ?? 0;
                ViewBag.TotalExpForMaterial = TotalExpensesForMaterial;

                // Total Expenses For the Housing Project  مجموع المصاريف للمشروع
                var TotalExpenses = TotalExpensesForManPower + TotalExpensesForMaterial;
                ViewBag.TotalExpenses = TotalExpenses;




                VM.Housing = db.Housings.Find(id);
                VM.List_Of_ManPowerCousts = db.ManPowerCousts.Where(a => a.Housing_ID == id).ToList();
                VM.List_Of_Material_Expenses = db.Material_Expenses.Where(a => a.Housing_ID == id).ToList();


                if (VM == null)
                {
                    return HttpNotFound();
                }




                return View(VM);

                /************************************************************/

                //var xx = from T in db.ManPowerCousts
                //         where T.Housing_ID == id
                //         orderby T.Parson_Name
                //         group T by T.Parson_Name into g
                //         select new
                //         {
                //             PName = g.Key,
                //             Total = g.Sum(x => x.Coust),

                //         };

                //var CostDet = db.ManPowerCousts.Where(a => a.Housing_ID == id)
                //                          .OrderBy(s => s.Parson_Name)
                //                          .GroupBy(d => d.Parson_Name)
                //                          .Select(ss => new { PName = ss.Key, PCoust = ss.Sum(A => A.Coust) });
                //return View(CostDet.ToList());

                /************************************************************/

            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        


        [HttpGet]
        public ActionResult SomeSelectedManpowerCosts(int id, string name)
        {
            double powerCousts = db.ManPowerCousts.Where(a => a.Housing_ID == id && a.Parson_Name == name).Sum(a => a.Coust);
            return Json(powerCousts, JsonRequestBehavior.AllowGet);
        }


        // GET: Housing/Housings/Create
        public ActionResult Create(int? id)
        {
            if (Session["Company"] != null)
            {
                ViewModel vm = new ViewModel();
                vm.List_Of_Countries = FillCountries();
                vm.List_Of_Cities = FillCities();
                TempData["CompanyID"] = id;
                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        public List<Country> FillCountries()
        {
            List<Country> countries = db.Countries.ToList();
            return countries;
        }

        public List<City> FillCities()
        {
            List<City> cities = db.Cities.ToList();
            return cities;
        }

        // POST: Housing/Housings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Housing housing, HttpPostedFileBase imgfile)
        {
            if (Session["Company"] != null)
            {
                if (ModelState.IsValid)
                {
                    housing.Company_ID = id;
                    TempData["CompanyID"] = id;

                    string path = "";
                    if (imgfile.FileName.Length > 0)
                    {
                        path = "/Image/" + Path.GetFileName(imgfile.FileName);
                        imgfile.SaveAs(Server.MapPath(path));
                    }
                    housing.Logo = path;


                    db.Housings.Add(housing);
                    db.SaveChanges();
                    return RedirectToAction("Chose_Project", new { @id = id });
                }

                ViewModel vm = new ViewModel();
                TempData["CompanyID"] = id;
                vm.List_Of_Countries = FillCountries();
                vm.List_Of_Cities = FillCities();
                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }


            //ViewBag.City_ID = new SelectList(db.Cities, "ID", "Name", housing.City_ID);
            //ViewBag.Company_ID = new SelectList(db.Companies, "ID", "Name", housing.Company_ID);
            //ViewBag.Country_ID = new SelectList(db.Countries, "ID", "Name", housing.Country_ID);
            //return View(housing);
        }



        // GET: Housing/Housings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Company"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Housing housing = db.Housings.Find(id);
                if (housing == null)
                {
                    return HttpNotFound();
                }
                ViewBag.City_ID = new SelectList(db.Cities, "ID", "Name", housing.City_ID);
                ViewBag.Company_ID = new SelectList(db.Companies, "ID", "Name", housing.Company_ID);
                ViewBag.Country_ID = new SelectList(db.Countries, "ID", "Name", housing.Country_ID);
                return View(housing);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        // POST: Housing/Housings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Housing housing, HttpPostedFileBase imgfile)
        {
            if (Session["Company"] != null)
            {
                string path = "";
                if (imgfile.FileName.Length > 0)
                {
                    path = "/Image/" + Path.GetFileName(imgfile.FileName);
                    imgfile.SaveAs(Server.MapPath(path));
                }
                housing.Logo = path;


                if (ModelState.IsValid)
                {
                    db.Entry(housing).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Chose_Project", new { id = housing.Company_ID });
                }

                ViewBag.City_ID = new SelectList(db.Cities, "ID", "Name", housing.City_ID);
                ViewBag.Company_ID = new SelectList(db.Companies, "ID", "Name", housing.Company_ID);
                ViewBag.Country_ID = new SelectList(db.Countries, "ID", "Name", housing.Country_ID);

                Session["ID"] = housing.ID;
                return View(housing);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        // GET: Housing/Housings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Company"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Housing housing = db.Housings.Find(id);
                if (housing == null)
                {
                    return HttpNotFound();
                }
                return View(housing);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        // POST: Housing/Housings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (Session["Company"] != null)
            {
                Housing housing = db.Housings.Find(id);
                db.Housings.Remove(housing);
                db.SaveChanges();
                return RedirectToAction("Chose_Project");
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
