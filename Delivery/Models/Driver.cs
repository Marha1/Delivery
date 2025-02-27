using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Models
{
    public class Driver : BaseModel
    {
        public string CancelPassword { get; set; }
        public string LicenseNumber { get; set; }

        public int FlightId { get; set; }  // Один текущий рейс
        public Flight CurrentFlight { get; set; }  // Один текущий рейс для водителя
        public ICollection<HistoryOfFlight> HistoryOfFlight { get; set; } = new List<HistoryOfFlight>();
    }

}
