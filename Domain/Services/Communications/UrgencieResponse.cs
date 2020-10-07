using Practincado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practincado.Domain.Services.Communications
{
    public class UrgencieResponse : BaseResponse<Urgencie>
    {
        public UrgencieResponse(Urgencie resource) : base(resource)
        {
        }

        public UrgencieResponse(string message) : base(message)
        {
        }
    }
}
