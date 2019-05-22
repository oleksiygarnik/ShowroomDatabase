using DatabaseCar.Data_Access_Layer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class Car
    {
        public int Id { get; set; }


        public int? ColorId { get; set; }
        public Color Color { get; set; }

        public int? ModelId { get; set; }
        public Model Model { get; set; }

        public int? BrandId { get; set; }
        public Brand Brand { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal Price { get; set; }

        public StatusCar Status { get; set; }

        public IEnumerable<CarPurchaseContract> CarPurchaseContracts { get; set; }

        public Car()
        {
            CarPurchaseContracts = new List<CarPurchaseContract>();
        }
    }
}
