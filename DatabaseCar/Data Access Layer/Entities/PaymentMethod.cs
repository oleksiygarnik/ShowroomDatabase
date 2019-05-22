using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SellDocument> SellDocuments { get; set; }

        public PaymentMethod()
        {
            SellDocuments = new List<SellDocument>();
        }
    }
}
