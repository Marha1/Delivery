using Delivery.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Models
{
    public class Auth
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public Driver Driver { get; set; } 
        public Operator Operator { get; set; }
    }

}
