using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Practincado.Resources
{
    public class SaveUrgencieResource
    {
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}
