using Practincado.Domain.Models;
using Practincado.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practincado.Domain.Services
{
    public interface IGuardianService
    {
        Task<IEnumerable<Guardian>> ListAsync();
        Task<GuardianResponse> GetByIdAsync(int id);
        Task<GuardianResponse> SaveAsync(Guardian guardian);
        Task<GuardianResponse> UpdateAsync(int id, Guardian guardian);
        Task<GuardianResponse> DeleteAsync(int id);
    }
}
