using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseCar.Data_Access_Layer.EFDataContext;
using DatabaseCar.Data_Access_Layer.Entities;
using DatabaseCar.Presentation_Access_Layer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCar.Controllers
{
    public class SysAdminController : Controller
    {
        private ShowroomContext db;

        public SysAdminController(ShowroomContext context)
        {
            db = context;
        }


        public ActionResult Index()
        {
            SysAdminViewModel vm = new SysAdminViewModel();
            vm.Tables = db.Tables.Where(t => t.Position.Name == "SysAdmin").ToList();
            ViewData["db"] = "Default";
            return View(vm);
        }

        [Route("sysadmin/index/{table}")]
        public ActionResult Index(string table)
        {
            SysAdminViewModel vm = new SysAdminViewModel();
            ViewData["db"] = table;
            vm.ITWorkApplications = db.ITWorkApplications.Include(p => p.Employee).ToList();
            vm.Tables = db.Tables.Where(t => t.Position.Name == "SysAdmin").ToList();

            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateITApplication()
        {
            ViewBag.Employees = db.Employees.Include(e => e.EmploymentContract).Where(e => e.EmploymentContract.Position.Name == "SysAdmin").ToList();
            return View();
        }


        [HttpPost]
        public ActionResult CreateITApplication(ITWorkApplication work)
        {
            work.Status = Data_Access_Layer.Entities.Enums.StatusIT.InProcess;
            db.Entry(work).State = EntityState.Added;
            db.SaveChanges();
            ViewBag.right = true;
            return View();
        }




        [HttpGet]
        public ActionResult EditITApplication(int? id)
        {
            ITWorkApplication work = db.ITWorkApplications.Find(id);
            work.Status = Data_Access_Layer.Entities.Enums.StatusIT.Done;
            db.Entry(work).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult EditITApplication(ITWorkApplication work)
        {
            //work.Status = Data_Access_Layer.Entities.Enums.StatusIT.InProcess;
            db.Entry(work).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteITApplication(int id)
        {
            ITWorkApplication work = db.ITWorkApplications.Find(id);
            if (work != null)
            {
                db.ITWorkApplications.Remove(work);
                db.SaveChanges();
            }
            ViewBag.Id = id;
            return RedirectToAction("Index");
        }
    }
}
