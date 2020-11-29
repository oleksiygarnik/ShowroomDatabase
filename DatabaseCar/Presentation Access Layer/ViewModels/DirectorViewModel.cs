using DatabaseCar.Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Presentation_Access_Layer.ViewModels
{
    public class DirectorViewModel
    {
        public List<Table> Tables { get; set; }
        public List<Command> Commands { get; set; }
        public List<Payroll> Payrolls { get; set; }
        public List<SickLeave> SickLeaves { get; set; }
        public List<TripOrder> TripOrders { get; set; }
        public List<VacationDocument> VacationDocuments { get; set; }
        public List<PurchaseContract> PurchaseContracts { get; set; }
        public List<EmploymentContract> EmploymentContracts { get; set; }
        public List<SellDocument> SellDocuments { get; set; }

        public DirectorViewModel()
        {
            Tables = new List<Table>();
            Commands = new List<Command>();
            Payrolls = new List<Payroll>();
            SickLeaves = new List<SickLeave>();
            TripOrders = new List<TripOrder>();
            VacationDocuments = new List<VacationDocument>();
            PurchaseContracts = new List<PurchaseContract>();
            EmploymentContracts = new List<EmploymentContract>();
            SellDocuments = new List<SellDocument>();
        }
    }
}
