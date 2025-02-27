using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string PassNumber { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        
        public int AuthId { get; set; }
        public Auth Auth { get; set; }
    }
}
