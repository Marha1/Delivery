using Delivery.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public TypeOfCargo type { get; set; }
        public  double Weight {  get; set; }
        
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
