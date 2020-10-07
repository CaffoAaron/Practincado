using Microsoft.EntityFrameworkCore;
using Practincado.Domain.Models;
using Practincado.Domain.Persistence.Contexts;
using Practincado.Domain.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practincado.Persistence.Respositories
{
    public class UrgencieRepository : BaseRepository, IUrgenciRepository
    {
        public UrgencieRepository(AppDbContext context) : base(context)
        {
        }

        public async Task Addsync(Urgencie guardian)
        {
            await _context.Urgencies.AddAsync(guardian);
        }

        public async Task<Urgencie> FindById(int id)
        {
            return await _context.Urgencies.FindAsync(id);
        }

        public async Task<IEnumerable<Urgencie>> ListAsync()
        {
            return await _context.Urgencies.ToListAsync();
        }

        public async Task<IEnumerable<Urgencie>> ListByGuardianIdAsync(int guardianId)
        {
            return await _context.Urgencies.Where(p => p.GuardianId == guardianId)
                .Include(p => p.Guardian).ToListAsync();
        }

        public void Remove(Urgencie guardian)
        {
            _context.Urgencies.Remove(guardian);
        }

        public void Update(Urgencie guardian)
        {
            _context.Urgencies.Update(guardian);
        }
    }
}
