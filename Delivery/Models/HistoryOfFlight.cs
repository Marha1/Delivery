using Delivery.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Models
{
    public class HistoryOfFlight
    {
         
        public int Id { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public string FlightName { get; set; }
        public string StartingPoint { get; set; }
        public string EndPoint { get; set; }

        public StatusOfDelievery Status { get; set; } = StatusOfDelievery.Waiting;
        private DateTime _DispatchDate { get; set; }
        private DateTime _ArrivalDate { get; set; }

        public DateTime DispatchDate
        {
            get => _DispatchDate;
            set => _DispatchDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public DateTime ArrivalDate
        {
            get => _ArrivalDate;
            set => _ArrivalDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        public TypeOfCargo type { get; set; }
        public double Weight { get; set; }

    }
}
