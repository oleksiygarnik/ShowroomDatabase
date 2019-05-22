using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.Entities
{
    public class Model
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public double Long { get; set; }

        public IEnumerable<Car> Cars { get; set; }

        public Model()
        {
            Cars = new List<Car>();
        }
    }
}
