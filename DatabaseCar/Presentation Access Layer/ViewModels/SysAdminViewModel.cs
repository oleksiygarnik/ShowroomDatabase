using DatabaseCar.Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Presentation_Access_Layer.ViewModels
{
    public class SysAdminViewModel
    {
        public List<Table> Tables { get; set; }
        public List<ITWorkApplication> ITWorkApplications { get; set; }

        public SysAdminViewModel()
        {
            ITWorkApplications = new List<ITWorkApplication>();
        }
    }
}
