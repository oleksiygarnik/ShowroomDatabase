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
    public class AccountantController : Controller
    {
        private ShowroomContext db;

        public AccountantController(ShowroomContext context)
        {
            db = context;
        }

    
        public ActionResult Index()
        {
            AccountantViewModel vm = new AccountantViewModel();
            vm.Tables = db.Tables.Where(t => t.Position.Name == "Accountant").ToList();
            ViewData["db"] = "Default"; 
            return View(vm);
        }

        [Route("accountant/index/{table}")]
        public ActionResult Index(string table)
        {
            AccountantViewModel vm = new AccountantViewModel();
            ViewData["db"] = table;
            vm.Payrolls = db.Payrolls.Include(p => p.Employee).ToList();
            vm.FinanceReports = db.FinanceReports.Include(f => f.Employee).ToList();
            vm.Tables = db.Tables.Where(t => t.Position.Name == "Accountant").ToList();

            ViewBag.Employees = db.Employees;

            return View(vm);
        }

        [HttpGet]
        public ActionResult CreatePayroll()
        {
            ViewBag.Employees = db.Employees.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult CreateFinanceReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePayroll(Payroll payroll)
        {
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Waiting;
            db.Entry(payroll).State = EntityState.Added;
            db.SaveChanges();
            ViewBag.right = true;
            return Redirect("/accountant/index/payrolls");
        }

        [HttpPost]
        public ActionResult CreateFinanceReport(FinanceReport financeReport)
        {
            db.Entry(financeReport).State = EntityState.Added;
            db.SaveChanges();
            ViewBag.right = true;
            return View();
        }

        public ActionResult DeletePayroll(int id)
        {
            Payroll payroll = db.Payrolls.Find(id);
            if (payroll != null)
            {
                db.Payrolls.Remove(payroll);
                db.SaveChanges();
            }
            ViewBag.Id = id;
            return RedirectToAction("Index");
        }


        public ActionResult DeleteFinanceReport(int id)
        {
            FinanceReport financeReport = db.FinanceReports.Find(id);
            if (financeReport != null)
            {
                db.FinanceReports.Remove(financeReport);
                db.SaveChanges();
            }
            ViewBag.Id = id;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPayroll(int? id)
        {
            Payroll payroll = db.Payrolls.Find(id);
            return View(payroll);
            
        }


        [HttpGet]
        public ActionResult EditFinanceReport(int? id)
        {
            FinanceReport financeReport = db.FinanceReports.Find(id);
            return View(financeReport);

        }


        [HttpPost]
        public ActionResult EditPayroll(Payroll payroll)
        {
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Waiting;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditFinanceReport(FinanceReport financeReport)
        {
            db.Entry(financeReport).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}