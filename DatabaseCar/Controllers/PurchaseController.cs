using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseCar.Data_Access_Layer.EFDataContext;
using DatabaseCar.Data_Access_Layer.Entities;
using DatabaseCar.Presentation_Access_Layer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCar.Controllers
{
    public class PurchaseManagerController : Controller
    {
        private ShowroomContext context;

        public PurchaseManagerController(ShowroomContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            PurchaseViewModel vm = new PurchaseViewModel();

            vm.Tables = context.Tables.Where(t => t.Position.Name == "PurchaseManager").ToList();//??????????????????????????????????
            vm.PurchaseContracts = context.PurchaseContracts.Include(pc => pc.CarPurchaseContracts).ToList();
            vm.Cars = context.Cars.Include(c => c.Brand).Include(c => c.Model).Include(c => c.Color).ToList();
            ViewData["db"] = "Default";

            return View(vm);
        }

        [Route("purchasemanager/index/{table}")]
        public IActionResult Index(string table)
        {
            PurchaseViewModel vm = new PurchaseViewModel();

            vm.Tables = context.Tables.Where(t => t.Position.Name == "Purchase").ToList();//??????????????????????????????????
            vm.PurchaseContracts = context.PurchaseContracts.Include(pc => pc.CarPurchaseContracts).ToList();
            vm.Cars = context.Cars.Include(c => c.Brand).Include(c => c.Model).Include(c => c.Color).ToList();

            ViewData["db"] = table;

            return View(vm);
        }

        public ActionResult CreateCar()
        {
            ViewBag.Brands = context.Brands;
            ViewBag.Models = context.Models;
            ViewBag.Colors = context.Colors;
            return View();
        }

        [HttpPost]
        public ActionResult CreateCar(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCar(int? id)
        {
            Car car = context.Cars.Find(id);
            ViewBag.Brands = context.Brands;
            ViewBag.Models = context.Models;
            ViewBag.Colors = context.Colors;

            return View(car);
        }

        [HttpPost]
        public ActionResult EditCar(Car car)
        {
            car.Status = Data_Access_Layer.Entities.Enums.StatusCar.Available;
            context.Entry(car).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCar(int id)
        {
            Car car = context.Cars.Find(id);
            if (car != null)
            {
                context.Cars.Remove(car);
                context.SaveChanges();
            }
            ViewBag.Id = id;
            return RedirectToAction("Index");
        }

        public ActionResult CreatePurchaseContract()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePurchaseContract(PurchaseContract purchaseContract)
        {
            context.PurchaseContracts.Add(purchaseContract);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPurchaseContract(int? id)
        {
            PurchaseContract purchaseContract = context.PurchaseContracts.Find(id);

            return View(purchaseContract);
        }

        [HttpPost]
        public ActionResult EditPurchaseContract(PurchaseContract purchaseContract)
        {
            purchaseContract.Status = Data_Access_Layer.Entities.Enums.Status.Waiting;
            context.Entry(purchaseContract).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletePurchaseContract(int id)
        {
            PurchaseContract purchaseContract = context.PurchaseContracts.Find(id);
            if (purchaseContract != null)
            {
                context.PurchaseContracts.Remove(purchaseContract);
                context.SaveChanges();
            }
            ViewBag.Id = id;
            return RedirectToAction("Index");
        }
    }
}