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
    public class UrgencieService : IUrgencieService
    {
        private readonly IUrgenciRepository _urgenciRepository;
        private readonly IGuardianRepository _guardianRepository;

        public UrgencieService(IUrgenciRepository urgenciRepository, IGuardianRepository guardianRepository)
        {
            _urgenciRepository = urgenciRepository;
            _guardianRepository = guardianRepository;
        }

        public async Task<UrgencieResponse> DeleteAsync(int id)
        {
            var existingUrgencie = await _urgenciRepository.FindById(id);
            if (existingUrgencie == null)
                return new UrgencieResponse("Urgencie not found");
            try
            {
                _urgenciRepository.Remove(existingUrgencie);

                return new UrgencieResponse(existingUrgencie);
            }
            catch (Exception ex)
            {
                return new UrgencieResponse($"An error ocurred while deleting Urgencie: {ex.Message}");
            }
        }

        public async Task<UrgencieResponse> GetByIdAsync(int id)
        {
            var existingUrgencie = await _urgenciRepository.FindById(id);
            if (existingUrgencie == null)
                return new UrgencieResponse("Urgencie not found");
            return new UrgencieResponse(existingUrgencie);

        }

        public async Task<IEnumerable<Urgencie>> ListAsync()
        {
            return await _urgenciRepository.ListAsync();
        }

        public async Task<IEnumerable<Urgencie>> ListByGuardianIdAsnc(int guardianId)
        {
            return await _urgenciRepository.ListByGuardianIdAsync(guardianId);
        }

        public async Task<UrgencieResponse> SaveAsync(Urgencie urgencie)
        {
            try
            {
                await _urgenciRepository.Addsync(urgencie);

                return new UrgencieResponse(urgencie);
            }
            catch (Exception ex)
            {
                return new UrgencieResponse($"An error ocurred while saving Urgencie: {ex.Message}");
            }
        }

        public async Task<UrgencieResponse> UpdateAsync(int id, Urgencie urgencie)
        {
            var existingUrgencie = await _urgenciRepository.FindById(id);
            if (existingUrgencie == null)
                return new UrgencieResponse("Urgencie not found");

            existingUrgencie.Title = urgencie.Title;
            existingUrgencie.Summary = urgencie.Summary;
            existingUrgencie.Latitude = urgencie.Latitude;
            existingUrgencie.Longitude = urgencie.Longitude;

            try
            {
                _urgenciRepository.Update(existingUrgencie);
                return new UrgencieResponse(urgencie);
            }
            catch (Exception ex)
            {
                return new UrgencieResponse($"An error ocurred while saving Urgencie: {ex.Message}");
            }
        }
    }
}
