using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEndEleccions.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEleccionsM.Repository
{
    public class VotsPerPartitRepository : IVotsPerPartitRepository
    {
        private readonly DataContext _context;

        public VotsPerPartitRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateVotsPerPartit(VotsPerPartit votsPerPartit)
        {
            _context.Add(votsPerPartit);
            return await Save();
        }

        public async Task<bool> DeleteVotsPerPartit(VotsPerPartit votsPerPartit)
        {
            _context.Remove(votsPerPartit);
            return await Save();
        }

        public async Task<VotsPerPartit> GetVotsPerPartit(int id)
        {
            return await _context.VotsPerPartit.FirstOrDefaultAsync(c => c.ID == id);
        }


        public async Task<ICollection<VotsPerPartit>> GetVotsPerPartits()
        {
            return await _context.VotsPerPartit.ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateVotsPerPartit(VotsPerPartit votsPerPartit)
        {
            _context.Update(votsPerPartit);
            return await Save();
        }

        public bool VotsPerPartitExists(int votsPerPartitId)
        {
            return  _context.VotsPerPartit.Any(c => c.ID == votsPerPartitId);
        }
    }
}
