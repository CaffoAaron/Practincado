using Practincado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practincado.Resources
{
    public class UrgencieResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime ReportedAt { get; set; }
        public Guardian Guardian { get; set; }
    }
}
