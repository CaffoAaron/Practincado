using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Practincado.Domain.Models;
using Practincado.Resources;

namespace Practincado.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Guardian, GuardianResource>();
            CreateMap<Urgencie, UrgencieResource>();
        }
    }
}
