using Practincado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practincado.Domain.Respositories
{
    public interface IGuardianRepository
    {
        Task<IEnumerable<Guardian>> ListAsync();
        Task Addsync(Guardian guardian);
        Task<Guardian> FindById(int id);
        void Update(Guardian guardian);
        void Remove(Guardian guardian);
    }
}
