using DatabaseCar.Data_Access_Layer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class PurchaseContract
    {
        public int Id { get; set; }

        public string SupplierName { get; set; }

        public DateTime Date { get; set; }

        public Status Status { get; set; }

        public IEnumerable<CarPurchaseContract> CarPurchaseContracts { get; set; }

        public PurchaseContract()
        {
            CarPurchaseContracts = new List<CarPurchaseContract>();
        }
    }
}
