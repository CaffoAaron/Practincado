using Practincado.Domain.Models;
using Practincado.Domain.Respositories;
using Practincado.Domain.Services;
using Practincado.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practincado.Services
{
    public class GuardinaService : IGuardianService
    {
        private readonly IGuardianRepository _guardianRepository;

        public GuardinaService(IGuardianRepository guardianRepository)
        {
            _guardianRepository = guardianRepository;
        }

        public async Task<GuardianResponse> DeleteAsync(int id)
        {
            var existingGuardian = await _guardianRepository.FindById(id);
            if (existingGuardian == null)
                return new GuardianResponse("Guardian not found");
            try 
            {
                _guardianRepository.Remove(existingGuardian);
                return new GuardianResponse(existingGuardian);
            }
            catch(Exception ex)
            {
                return new GuardianResponse($"An error ocurred while deleting guardian: {ex.Message}");
            }
        }

        public async  Task<GuardianResponse> GetByIdAsync(int id)
        {
            var existingGuardian = await _guardianRepository.FindById(id);
            if (existingGuardian == null)
                return new GuardianResponse("Guardian not found");
            return new GuardianResponse(existingGuardian);
        }

        public async Task<IEnumerable<Guardian>> ListAsync()
        {
            return await _guardianRepository.ListAsync();
        }

        public async Task<GuardianResponse> SaveAsync(Guardian guardian)
        {
            try
            {
                await _guardianRepository.Addsync(guardian);
                return new GuardianResponse(guardian);
            }
            catch(Exception ex)
            {
                return new GuardianResponse($"An error ocurred while deleting guardian: {ex.Message}");
            }
        }

        public async Task<GuardianResponse> UpdateAsync(int id, Guardian guardian)
        {
            var existingGuardian = await _guardianRepository.FindById(id);
            if (existingGuardian == null)
                return new GuardianResponse("Guardian not found");
            existingGuardian.FirstName = guardian.FirstName;
            existingGuardian.LastName = guardian.LastName;
            existingGuardian.Email = guardian.Email;
            existingGuardian.Address = guardian.Address;
            existingGuardian.Gender = guardian.Gender;
            try
            {
                _guardianRepository.Update(existingGuardian);
                return new GuardianResponse(existingGuardian);
            }
            catch (Exception ex)
            {
                return new GuardianResponse($"An error ocurred while deleting guardian: {ex.Message}");
            }
        }
    }
}
