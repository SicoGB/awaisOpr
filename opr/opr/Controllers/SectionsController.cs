using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using opr.Models;

namespace opr.Controllers
{
    [Authorize]
    public class SectionsController : Controller
    {
        // GET: Sections
        public ActionResult Index()
        {


            Models.oprEntities dbs = new oprEntities();
            var mod = dbs.DefTables.Select(s => new { s.TableId, s.TableName }).ToList();
            SelectList selectList = new SelectList(mod, "TableName", "TableName");
            ViewBag.dataForDropDown = selectList;

            var mods = dbs.DefControls.Select(c => new { c.ControId, c.ControlName }).ToList();
            SelectList selectLists = new SelectList(mods, "ControlName", "ControlName");
            ViewBag.dataForDropDowns = selectLists;

            Section model = new Section();
            model.IsDeleted = true;
            model.IsActive = true;
            //model.UserId= User.Identity.Name;
            //ViewBag.InitialValue = "initialvalue";
            //ViewData["ee"] = User.Identity.Name;
            ViewBag.InitialValue = User.Identity.Name;
            ViewBag.DateTime = DateTime.Now;
            return View(new Section());
        }
        [HttpPost]
        public ActionResult Index(opr.Models.Section model)

        {

            Models.oprEntities dbs = new oprEntities();
            var mod = dbs.DefTables.Select(s => new { s.TableId, s.TableName }).ToList();
            SelectList selectList = new SelectList(mod, "TableName", "TableName");
            ViewBag.dataForDropDown = selectList;

            var mods = dbs.DefControls.Select(c => new { c.ControId, c.ControlName }).ToList();
            SelectList selectLists = new SelectList(mods, "ControlName", "ControlName");
            ViewBag.dataForDropDowns = selectLists;

            model.IsDeleted = true;
            model.IsActive = true;

            opr.Models.oprEntities  db = new oprEntities();
            try
            {
                db.Sections.Add(model);
                db.SaveChanges();
            }
            
                        catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return View(new Section());
        }
        public ActionResult SectionDetail()
        {

            Models.oprEntities dbs = new oprEntities();
            var mod = dbs.DefTables.Select(s => new { s.TableId, s.TableName }).ToList();
            SelectList selectList = new SelectList(mod, "TableName", "TableName");
            ViewBag.dataForDropDown = selectList;

            var mods = dbs.DefControls.Select(c => new { c.ControId, c.ControlName }).ToList();
            SelectList selectLists = new SelectList(mods, "ControlName", "ControlName");
            ViewBag.dataForDropDowns = selectLists;

            Models.oprEntities db = new oprEntities();
            IList<Models.Section> model = new List<Section>();
            model = db.Sections.ToList();

            return View(model);

        }

        //public ActionResult DeleteData(int id)
        //{
        //    Models.oprEntities db = new oprEntities();
        //    Section Sectiondt = db.Sections.Find(id);

        //    db.Sections.Remove(Sectiondt);
        //    db.SaveChanges();
        //    return RedirectToAction("SectionDetail");
        //}

        //public ActionResult DeleteData(int id)
        //{
        //    Models.oprEntities db = new oprEntities();
        //    Section Sectiondt = db.Sections.Find(id);
        //    return View(Sectiondt);

        //    //var user = new User() { Id = userId, Password = password };
        //    //using (var db = new MyEfContextName())
        //    //{
        //    //    db.Users.Attach(user);
        //    //    db.Entry(user).Property(x => x.Password).IsModified = true;
        //    //    db.SaveChanges();
        //    //}
        //    //return RedirectToAction("Index");
        //}

        public ActionResult DeleteData(int id)
        {
            Section model = new Section();
            model.IsDeleted = true;
            Models.oprEntities db = new oprEntities();
            Section Sectiondt = db.Sections.Find(id);
            return View(Sectiondt);
        }

        [HttpPost]
        public ActionResult DeleteData(opr.Models.Section model)
        {
            Models.oprEntities db = new oprEntities();
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            try
            {

                db.SaveChanges();
                return RedirectToAction("SectionDetail");
            }
            catch
            {

            }
            ModelState.AddModelError("", "Unable to save changes");
            return View(model);
        }

        public ActionResult EditView(int id)
        {

            Models.oprEntities dbs = new oprEntities();
            var mod = dbs.DefTables.Select(s => new { s.TableId, s.TableName }).ToList();
            SelectList selectList = new SelectList(mod, "TableName", "TableName");
            ViewBag.dataForDropDown = selectList;

            var mods = dbs.DefControls.Select(c => new { c.ControId, c.ControlName }).ToList();
            SelectList selectLists = new SelectList(mods, "ControlName", "ControlName");
            ViewBag.dataForDropDowns = selectLists;

            Models.oprEntities db = new oprEntities();
            Section Sectiondt = db.Sections.Find(id);
            return View(Sectiondt);
        }
        [HttpPost]
        public ActionResult EditView(opr.Models.Section model)
        {

            Models.oprEntities dbs = new oprEntities();
            var mod = dbs.DefTables.Select(s => new { s.TableId, s.TableName }).ToList();
            SelectList selectList = new SelectList(mod, "TableName", "TableName");
            ViewBag.dataForDropDown = selectList;

            var mods = dbs.DefControls.Select(c => new { c.ControId, c.ControlName }).ToList();
            SelectList selectLists = new SelectList(mods, "ControlName", "ControlName");
            ViewBag.dataForDropDowns = selectLists;

            Models.oprEntities db = new oprEntities();
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            try
            {

                db.SaveChanges();
                return RedirectToAction("SectionDetail");
            }
            catch
            {

            }
            ModelState.AddModelError("", "Unable to save changes");
            return View(model);
        }
        public ActionResult Create()
        {
            Models.oprEntities db = new oprEntities();
            var mod = db.DefTables.Select(s => new { s.TableId,s.TableName }).ToList();
            SelectList selectList = new SelectList(mod, "TableName", "TableName");
            ViewBag.dataForDropDown = selectList;

            var mods = db.DefControls.Select(c => new { c.ControId, c.ControlName }).ToList();
            SelectList selectLists = new SelectList(mods, "TableName", "ControlName");
            ViewBag.dataForDropDowns = selectLists;

            //Section model = new Section();
            //model.IsDeleted = true;
            //model.IsActive = true;
            ////model.UserId= User.Identity.Name;
            ////ViewBag.InitialValue = "initialvalue";
            ////ViewData["ee"] = User.Identity.Name;
            //ViewBag.InitialValue = User.Identity.Name;
            //ViewBag.DateTime = DateTime.Now;
            return View();
        }
        [HttpPost]
        public string Create(opr.Models.CustomeFeild model)

        {

            Models.oprEntities dbs = new oprEntities();
            var mod = dbs.DefTables.Select(s => new { s.TableId, s.TableName }).ToList();
            SelectList selectList = new SelectList(mod, "TableName", "TableName");
            ViewBag.dataForDropDown = selectList;

            var mods = dbs.DefControls.Select(c => new { c.ControId, c.ControlName }).ToList();
            SelectList selectLists = new SelectList(mods, "ControlName", "ControlName");
            ViewBag.dataForDropDowns = selectLists;


            //model.IsDeleted = true;
            //model.IsActive = true;

            opr.Models.oprEntities db = new oprEntities();
            db.CustomeFeilds.Add(model);
            db.SaveChanges();

            return "Saved successfully.";
        }
        public ActionResult Details()
        {

            Models.oprEntities dbs = new oprEntities();
            var mod = dbs.DefTables.Select(s => new { s.TableId, s.TableName }).ToList();
            SelectList selectList = new SelectList(mod, "TableName", "TableName");
            ViewBag.dataForDropDown = selectList;

            var mods = dbs.DefControls.Select(c => new { c.ControId, c.ControlName }).ToList();
            SelectList selectLists = new SelectList(mods, "ControlName", "ControlName");
            ViewBag.dataForDropDowns = selectLists;

            Models.oprEntities db = new oprEntities();
            IList<Models.CustomeFeild> model = new List<CustomeFeild>();
            model = db.CustomeFeilds.ToList();

            return View(model);

        }
    }
}