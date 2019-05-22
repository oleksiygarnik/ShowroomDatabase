using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class SellDocument
    {
        public int Id { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }

        public decimal Price { get; set; }

        public int? PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime SaleDate { get; set; }
    }
}
