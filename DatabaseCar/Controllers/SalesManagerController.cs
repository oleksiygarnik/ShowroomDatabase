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
    public class SalesManagerController : Controller
    {
        private ShowroomContext db;

        public SalesManagerController(ShowroomContext context)
        {
            db = context;
        }


        public ActionResult Index()
        {
            SalesManagerViewModel vm = new SalesManagerViewModel();
            vm.Tables = db.Tables.Where(t => t.Position.Name == "SalesManager").ToList();
            ViewData["db"] = "Default";
            return View(vm);
        }

        [Route("salesmanager/index/{table}")]
        public ActionResult Index(string table)
        {
            SalesManagerViewModel vm = new SalesManagerViewModel();
            ViewData["db"] = table;
            vm.Clients = db.Clients.Include(p => p.ContactInfo).ToList();
            vm.Cars = db.Cars.Include(c=>c.Brand).Include(c=>c.Color).Include(c=>c.Model).ToList();
            vm.SellDocuments = db.SellDocuments.Include(sd => sd.Car).Include(sd => sd.Client).Include(sd => sd.Employee).Include(sd => sd.PaymentMethod).ToList();
            vm.Tables = db.Tables.Where(t => t.Position.Name == "SalesManager").ToList();

            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateClient()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateSellDocument()
        {
            ViewBag.Employees = db.Employees.ToList();
            ViewBag.Cars = db.Cars.ToList();
            ViewBag.Clients = db.Clients.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult CreateClient(Client client)
        {
            db.Entry(client.ContactInfo).State = EntityState.Added;
            db.SaveChanges();

            db.Entry(client).State = EntityState.Added;
            //db.Entry(client.ContactInfo).State = EntityState.Added;
            db.SaveChanges();
            ViewBag.right = true;
            return View();
        }

        [HttpPost]
        public ActionResult CreateSellDocument(SellDocument sellDocument)
        {
            db.Entry(sellDocument).State = EntityState.Added;
         
            db.SaveChanges();
            ViewBag.right = true;
            return View();
        }

        public ActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client != null)
            {
                db.Clients.Remove(client);
                db.SaveChanges();
            }
            ViewBag.Id = id;
            return RedirectToAction("Index");
        }


        public ActionResult DeleteSellDocument(int id)
        {
            SellDocument sellDocument = db.SellDocuments.Find(id);
            if (sellDocument!= null)
            {
                db.SellDocuments.Remove(sellDocument);
                db.SaveChanges();
            }
            ViewBag.Id = id;
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
            ViewBag.Id = id;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditClient(int? id)
        {
            Client client = db.Clients.Find(id);
            return View(client);

        }


        [HttpGet]
        public ActionResult EditSellDocument(int? id)
        {
            SellDocument sellDocument = db.SellDocuments.Find(id);
            ViewBag.Employees = db.Employees.ToList();
            ViewBag.Cars = db.Cars.ToList();
            ViewBag.Clients = db.Clients.ToList();

            return View(sellDocument);

        }


        [HttpGet]
        public ActionResult EditCar(int? id)
        {
            Car car = db.Cars.Find(id);
            return View(car);

        }


        [HttpPost]
        public ActionResult EditClient(Client client)
        { 
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditCar(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult EditSellDocument(SellDocument sellDocument)
        {
            db.Entry(sellDocument).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
