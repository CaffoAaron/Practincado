using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practincado.Domain.Models
{
    public class Guardian
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public IList<Urgencie> Urgencies { get; set; } = new List<Urgencie>();
    }
}
