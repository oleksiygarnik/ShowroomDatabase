using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatabaseCar.Models;
using DatabaseCar.Data_Access_Layer.EFDataContext;
using Microsoft.EntityFrameworkCore;
using DatabaseCar.Presentation_Access_Layer.ViewModels;
using System.Configuration;

using Microsoft.IdentityModel.Protocols;
using System.Data.SqlClient;

namespace DatabaseCar.Controllers
{
    public class HomeController : Controller
    {
        private ShowroomContext db;

        public HomeController(ShowroomContext _db)
        {
            db = _db;

        }
        public IActionResult Index()
        {
            ViewData["db"] = "Payrolls";
            List<string> tablesName = new List<string>();

            AccountantViewModel vm = new AccountantViewModel();
            if (User.IsInRole("admin"))
            {

                vm.Payrolls = db.Payrolls.ToList();
                vm.FinanceReports = db.FinanceReports.ToList();


                //foreach (var entityType in db.Model.GetEntityTypes())
                //{
                //    var tableName = entityType.Relational().TableName;
                //    tablesName.Add(tableName);

                //    foreach (var propertyType in entityType.GetProperties())
                //    {
                //        var columnName = propertyType.Relational().ColumnName;
                //    }
                //}
            }
          
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
