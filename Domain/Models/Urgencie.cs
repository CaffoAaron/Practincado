using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practincado.Domain.Models
{
    public class Urgencie
    {
        public int Id { get; set; }
        public string Title { get; set;}
        public string Summary { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime ReportedAt { get; set; }
        public int GuardianId { get; set; }
        public Guardian Guardian { get; set; }

    }
}
