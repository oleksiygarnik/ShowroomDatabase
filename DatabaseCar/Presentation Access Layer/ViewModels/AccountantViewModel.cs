using DatabaseCar.Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Presentation_Access_Layer.ViewModels
{
    public class AccountantViewModel
    {
        public List<Table> Tables { get; set; }
        public List<Payroll> Payrolls { get; set; }
        public List<FinanceReport> FinanceReports { get; set; }

        public AccountantViewModel()
        {
            Payrolls = new List<Payroll>();
            FinanceReports = new List<FinanceReport>();
        }
    }
}
