using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using opr.Models;

namespace opr.Controllers
{
    public class SchoolRegController : Controller
    {
        SchoolModel SchoolModel = new SchoolModel();
        // GET: SchoolReg
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            //ViewBag.Campuses = new SelectList(CampusModel.GetAll(), "ID", "C_name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(opr.Models.school school, FormCollection form)
        {
            //if (Request["Campus"] == null)
            //{
            //    return Json(new { message = "Please select at least one campus to continue", type = "error" });
            //}
            //string campus = Request["Campus"];
            //string[] ids = campus.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var id in ids)
            //{
            //    school.school_campus.Add(new opr.Models.school_campus() { CampusID = int.Parse(id) });
            //}
            //int sid = SchoolModel.Add(school);
            //if (sid > 0)
            //{
            //    return Json(new { message = "Successfully stored record to database.", type = "success" });
            //    //return JavaScript("window.location='" + Url.Action("SchoolConfig", "Schools", new { area = "Admin",id=sid }) + "'");
            //}
            //else if (sid == -1)
            //{
            //    return Json(new { message = "School name already regstered", type = "error" });

            //}
            //else if (sid == -2)
            //{
            //    return Json(new { message = "Username already registered", type = "error" });

            //}
            return Json(new { message = "unable to store data. please view the log file or contact admin.", type = "error" });
        }
    }
}