using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Practincado.Resources
{
    public class SaveGuardianResources
    {
        [Required]
        [MaxLength(60)]
        public string Username { get; set; }
        [Required]
        [MaxLength(60)]
        public string Email { get; set; }
        [Required]
        [MaxLength(60)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
