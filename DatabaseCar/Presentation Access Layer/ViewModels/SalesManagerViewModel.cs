using DatabaseCar.Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Presentation_Access_Layer.ViewModels
{
    public class SalesManagerViewModel
    {
        public List<Table> Tables { get; set; }
        public List<Client> Clients { get; set; }
        public List<Car> Cars { get; set; }
        public List<SellDocument> SellDocuments { get; set; }

        public SalesManagerViewModel()
        {
            Clients = new List<Client>();
            Cars = new List<Car>();
            SellDocuments = new List<SellDocument>();
        }
    }
}
