using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEndEleccions.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEleccionsM.Repository
{
    public class PartitPoliticRepository : IPartitPoliticRepository
    {
        private readonly DataContext _context;

        public PartitPoliticRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePartitPolitic(PartitPolitic partitPolitic)
        {
            _context.Add(partitPolitic);
            return await Save();
        }

        public async Task<bool> DeletePartitPolitic(PartitPolitic partitPolitic)
        {
            _context.Remove(partitPolitic);
            return await Save();
        }

        public async Task<PartitPolitic> GetPartitPolitic(int id)
        {
            return await _context.PartitsPolitics.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<PartitPolitic> GetPartitPolitic(string name)
        {
            return await _context.PartitsPolitics.FirstOrDefaultAsync(p => p.NomPartit == name);
        }

		public async Task<ICollection<PartitPolitic>> GetPartitsPoliticsByMuniID(int muniID)
		{    
			return await _context.PartitsPolitics.Where(m => m.Municipi.ID == muniID).ToListAsync();
		}

		public async Task<ICollection<PartitPolitic>> GetPartitsPolitics()
        {
            return await _context.PartitsPolitics.ToListAsync();
        }

        public bool PartitPoliticExists(int partitId)
        {
            return _context.PartitsPolitics.Any(c => c.ID == partitId);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdatePartitPolitic(PartitPolitic partitPolitic)
        {
            _context.Update(partitPolitic);
            return await Save(); 
        }
    }
}
