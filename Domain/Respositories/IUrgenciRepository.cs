using Practincado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practincado.Domain.Respositories
{
    public interface IUrgenciRepository
    {
        Task<IEnumerable<Urgencie>> ListAsync();

        Task<IEnumerable<Urgencie>> ListByGuardianIdAsync(int guardianId);
        Task Addsync(Urgencie guardian);
        Task<Urgencie> FindById(int id);
        void Update(Urgencie guardian);
        void Remove(Urgencie guardian);
    }
}
