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
    public class GuardianRepository : BaseRepository, IGuardianRepository
    {
        public GuardianRepository(AppDbContext context) : base(context)
        {
        }

        public async Task Addsync(Guardian guardian)
        {
            await _context.Guardians.AddAsync(guardian);
        }

        public async Task<Guardian> FindById(int id)
        {
            return await _context.Guardians.FindAsync(id);
        }

        public async Task<IEnumerable<Guardian>> ListAsync()
        {
            return await _context.Guardians.ToListAsync();
        }

        public void Remove(Guardian guardian)
        {
            _context.Guardians.Remove(guardian);
        }

        public void Update(Guardian guardian)
        {
            _context.Guardians.Update(guardian);
        }
    }
}
