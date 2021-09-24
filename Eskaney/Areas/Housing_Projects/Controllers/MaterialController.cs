using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eskaney.Models;

namespace Eskaney.Areas.Housing_Projects.Controllers
{
    public class MaterialController : Controller
    {
        private Eskaney_Context db = new Eskaney_Context();

        // GET: Housing_Projects/Material
        public ActionResult Add_Material(int? id)
        {
            if (Session["Company"] != null)
            {
                var addMat = db.Housings.Where(a => a.ID == id).ToList().FirstOrDefault();
                TempData["HousingID"] = addMat.ID;
                TempData["ProjectName"] = addMat.Project_Name;
                TempData["Logo"] = addMat.Logo;
                var x = addMat.Company_ID;


                var com = db.Companies.Where(a => a.ID == x).FirstOrDefault();
                TempData["CompanyName"] = com.Name;
                ViewBag.Logo = addMat.Logo;
                ViewBag.ID = addMat.ID;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        // GET: Housing_Projects/Material/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material_Expenses material_Expenses = db.Material_Expenses.Find(id);
            if (material_Expenses == null)
            {
                return HttpNotFound();
            }
            return View(material_Expenses);
        }

        // GET: Housing_Projects/Material
        public ActionResult Material_Details(int? id)
        {
            if (Session["Company"] != null)
            {
                var Mat_Det = db.Housings.Where(a => a.ID == id).ToList().FirstOrDefault();
                TempData["HousingID"] = Mat_Det.ID;
                TempData["ProjectName"] = Mat_Det.Project_Name;
                TempData["Logo"] = Mat_Det.Logo;
                var x = Mat_Det.Company_ID;


                var com = db.Companies.Where(a => a.ID == x).FirstOrDefault();
                TempData["CompanyName"] = com.Name;

                ViewBag.Logo = Mat_Det.Logo;
                ViewBag.ID = Mat_Det.ID;

                var Material_Det = db.Material_Expenses.Where(a => a.Housing_ID == id).Include(m => m.housing);

                return View(Material_Det.ToList());
                //ViewBag.Housing_ID = new SelectList(db.Housings, "ID", "Project_Name");
                //return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
            
        }

        // POST: Housing_Projects/Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_Material(/*[Bind(Include = "ID,Material_Name,Material_Source,Quantity,Date,Coust,EnvoiceNumber,Notes,Housing_ID")] */ int id, Material_Expenses mat_Exp)
        {
            if (Session["Company"] != null)
            {
                if (ModelState.IsValid)
                {
                    mat_Exp.Housing_ID = id;
                    db.Material_Expenses.Add(mat_Exp);
                    db.SaveChanges();
                    return RedirectToAction("Material_Details", new { @id = mat_Exp.Housing_ID });
                }

                mat_Exp.Housing_ID = id;
                TempData["HousingID"] = id;
                ViewBag.ID = id;
                return View(mat_Exp);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        // GET: Housing_Projects/Material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Company"] != null)
            {
                var aa = db.Material_Expenses.Where(a => a.ID == id).ToList().FirstOrDefault();
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
                Material_Expenses material_Expenses = db.Material_Expenses.Find(id);
                if (material_Expenses == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Housing_ID = material_Expenses.Housing_ID;
                //ViewBag.Housing_ID = new SelectList(db.Housings, "ID", "Project_Name", material_Expenses.Housing_ID);
                return View(material_Expenses);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        // POST: Housing_Projects/Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "ID,Material_Name,Material_Source,Quantity,Date,Coust,EnvoiceNumber,Notes,Housing_ID")]*/ int id, Material_Expenses material_Expenses)
        {
            if (Session["Company"] != null)
            {
                var Mat_Ex = db.Material_Expenses.AsNoTracking().Where(a => a.ID == id).ToList().FirstOrDefault();
                var Housing_ID = Mat_Ex.Housing_ID;
                TempData["HousingID"] = Housing_ID;


                if (ModelState.IsValid)
                {
                    material_Expenses.Housing_ID = Housing_ID;
                    db.Entry(material_Expenses).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Material_Details", new { @id = material_Expenses.Housing_ID });
                }
                ViewBag.Housing_ID = material_Expenses.Housing_ID;
                return View(material_Expenses);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        // GET: Housing_Projects/Material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Company"] != null)
            {
                var Mat_Ex = db.Material_Expenses.AsNoTracking().Where(a => a.ID == id).ToList().FirstOrDefault();
                var Housing_ID = Mat_Ex.Housing_ID;
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
                Material_Expenses material_Expenses = db.Material_Expenses.Find(id);
                if (material_Expenses == null)
                {
                    return HttpNotFound();
                }
                return View(material_Expenses);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "Home" });
            }
        }

        // POST: Housing_Projects/Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Company"] != null)
            {
                Material_Expenses material_Expenses = db.Material_Expenses.Find(id);
                db.Material_Expenses.Remove(material_Expenses);
                db.SaveChanges();
                return RedirectToAction("Material_Details", new { @id = material_Expenses.Housing_ID });
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


        //public JsonResult getMaterials(int id)
        //{
        //    ViewData["ID"] = id;
        //    var Material = db.Material_Expenses.Where(a => a.Housing_ID == id).ToList();
        //    return Json(Material, JsonRequestBehavior.AllowGet);
        //}
    }
}
