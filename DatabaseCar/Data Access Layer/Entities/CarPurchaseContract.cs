using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class CarPurchaseContract
    {
        public int? CarId { get; set; }
        public Car Car { get; set; }

        public int? PurchaseContractId { get; set; }
        public PurchaseContract PurchaseContract { get; set; }

        public CarPurchaseContract() { }
    }
}
