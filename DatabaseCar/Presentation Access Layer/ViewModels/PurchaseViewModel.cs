using DatabaseCar.Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Presentation_Access_Layer.ViewModels
{
    public class PurchaseViewModel
    {
        public List<Car> Cars { get; set; }
        public List<Table> Tables { get; set; }
        public List<PurchaseContract> PurchaseContracts { get; set; }
    }
}
