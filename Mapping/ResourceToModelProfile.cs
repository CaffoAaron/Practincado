using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practincado.Resources;
using Practincado.Domain.Models;

namespace Practincado.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveGuardianResources, Guardian>();
            CreateMap<SaveUrgencieResource, Urgencie>();

        }
    }
}
