using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class Employee : Person
    {
 
        public string Email { get; set; }

        public string Password { get; set; }

        public int? EmploymentContractId { get; set; }
        public EmploymentContract EmploymentContract { get; set; }

        public IEnumerable<VacationDocument> VacationDocuments { get; set; }

        public IEnumerable<TripOrder> TripOrders { get; set; }

        public IEnumerable<SickLeave> SickLeaves { get; set; }

        public IEnumerable<Payroll> Payrolls { get; set; }

        public IEnumerable<ITWorkApplication> ITWorkApplications { get; set; }

        public IEnumerable<SellDocument> SellDocuments { get; set; }

        public IEnumerable<FinanceReport> FinanceReports { get; set; }


        public Employee()
        {
            VacationDocuments = new List<VacationDocument>();
            TripOrders = new List<TripOrder>();
            SickLeaves = new List<SickLeave>();
            Payrolls = new List<Payroll>();
            ITWorkApplications = new List<ITWorkApplication>();
            SellDocuments = new List<SellDocument>();
            FinanceReports = new List<FinanceReport>();
        }
    }
}
