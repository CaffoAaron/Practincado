using Practincado.Domain.Models;
using System;
using Practincado.Domain.Services.Communications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practincado.Domain.Services
{
    public interface IUrgencieService
    {
        Task<IEnumerable<Urgencie>> ListAsync();
        Task<IEnumerable<Urgencie>> ListByGuardianIdAsnc(int guardianId);
        Task<UrgencieResponse> GetByIdAsync(int id);
        Task<UrgencieResponse> SaveAsync(Urgencie urgencie);
        Task<UrgencieResponse> UpdateAsync(int id, Urgencie urgencie);
        Task<UrgencieResponse> DeleteAsync(int id);
    }
}
