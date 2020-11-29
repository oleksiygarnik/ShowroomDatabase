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
    public class DirectorController : Controller
    {
        private ShowroomContext db;

        public DirectorController(ShowroomContext context)
        {
            db = context;
        }


        public ActionResult Index()
        {
            DirectorViewModel vm = new DirectorViewModel();
            vm.Tables = db.Tables.Where(t => t.Position.Name == "Director").ToList();
            ViewData["db"] = "Default";
            return View(vm);
        }

        [Route("director/index/{table}")]
        public ActionResult Index(string table)
        {
            DirectorViewModel vm = new DirectorViewModel();
            ViewData["db"] = table;
            vm.Commands = db.Commands.Include(c=>c.Employee).ToList();
            vm.EmploymentContracts = db.EmploymentContracts.Include(c => c.Position).ToList();
            vm.Payrolls = db.Payrolls.Include(c => c.Employee).ToList();
            vm.PurchaseContracts = db.PurchaseContracts.ToList();
            vm.SickLeaves = db.SickLeaves.Include(s => s.Employee).ToList();
            vm.TripOrders = db.TripOrders.Include(s => s.Employee).ToList();
            vm.VacationDocuments = db.VacationDocuments.Include(s => s.Employee).ToList();
            vm.SellDocuments = db.SellDocuments.Include(s => s.Employee).Include(s => s.Car).Include(c => c.Client).ToList();
            vm.Tables = db.Tables.Where(t => t.Position.Name == "Director").ToList();

            return View(vm);
        }

        public ActionResult AcceptPayroll(int? id)
        {
            Payroll payroll = db.Payrolls.Find(id);
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Accept;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RejectPayroll(int? id)
        {
            Payroll payroll = db.Payrolls.Find(id);
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Reject;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AcceptSickLeave(int? id)
        {
            SickLeave payroll = db.SickLeaves.Find(id);
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Accept;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RejectSickLeave(int? id)
        {
            SickLeave payroll = db.SickLeaves.Find(id);
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Reject;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AcceptTripOrder(int? id)
        {
            TripOrder payroll = db.TripOrders.Find(id);
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Accept;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RejectTripOrder(int? id)
        {
            TripOrder payroll = db.TripOrders.Find(id);
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Reject;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AcceptVacationDocument(int? id)
        {
            VacationDocument payroll = db.VacationDocuments.Find(id);
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Accept;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RejectVacatinDocument(int? id)
        {
            VacationDocument payroll = db.VacationDocuments.Find(id);
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Reject;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AcceptPurchaseContract(int? id)
        {
            PurchaseContract payroll = db.PurchaseContracts.Find(id);
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Accept;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RejectPurchaseContract(int? id)
        {
            PurchaseContract payroll = db.PurchaseContracts.Find(id);
            payroll.Status = Data_Access_Layer.Entities.Enums.Status.Reject;
            db.Entry(payroll).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult AcceptEmploymentContract(int? id)
        //{
        //    EmploymentContract payroll = db.EmploymentContracts.Find(id);
        //    payroll.Status = Data_Access_Layer.Entities.Enums.Status.Accept;
        //    db.Entry(payroll).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult RejectEmploymentContract(int? id)
        //{
        //    EmploymentContract payroll = db.EmploymentContracts.Find(id);
        //    payroll.Status = Data_Access_Layer.Entities.Enums.Status.Reject;
        //    db.Entry(payroll).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult CreateCommand()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCommand(Command command)
        {
            //command.Status = Data_Access_Layer.Entities.Enums.Status.Waiting;
            db.Entry(command).State = EntityState.Added;
            db.SaveChanges();
            ViewBag.right = true;
            return View();
        }

       

        public ActionResult DeleteCommand(int id)
        {
            Command payroll = db.Commands.Find(id);
            if (payroll != null)
            {
                db.Commands.Remove(payroll);
                db.SaveChanges();
            }
            ViewBag.Id = id;
            return RedirectToAction("Index");
        }


    

        [HttpGet]
        public ActionResult EditCommand(int? id)
        {
            Command payroll = db.Commands.Find(id);
            return View(payroll);

        }



        [HttpPost]
        public ActionResult EditCommand(Command command)
        {
            //payroll.Status = Data_Access_Layer.Entities.Enums.Status.Waiting;
            db.Entry(command).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult CreateITApplication()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult CreateITApplication(ITWorkApplication work)
        //{
        //    work.Status = Data_Access_Layer.Entities.Enums.StatusIT.InProcess;
        //    db.Entry(work).State = EntityState.Added;
        //    db.SaveChanges();
        //    ViewBag.right = true;
        //    return View();
        //}




        //[HttpGet]
        //public ActionResult EditITApplication(int? id)
        //{
        //    ITWorkApplication work = db.ITWorkApplications.Find(id);
        //    work.Status = Data_Access_Layer.Entities.Enums.StatusIT.Done;
        //    db.Entry(work).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        //[HttpPost]
        //public ActionResult EditITApplication(ITWorkApplication work)
        //{
        //    //work.Status = Data_Access_Layer.Entities.Enums.StatusIT.InProcess;
        //    db.Entry(work).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult DeleteITApplication(int id)
        //{
        //    ITWorkApplication work = db.ITWorkApplications.Find(id);
        //    if (work != null)
        //    {
        //        db.ITWorkApplications.Remove(work);
        //        db.SaveChanges();
        //    }
        //    ViewBag.Id = id;
        //    return RedirectToAction("Index");
        //}
    }
}