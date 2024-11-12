using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEndEleccions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEleccionsM.Repository
{
    public class TaulaElectoralRepository : ITaulaElectoralRepository
    {
        private readonly DataContext _context;

        public TaulaElectoralRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTaulaElectoral(TaulaElectoral taulaElectoral)
        {

            _context.Add(taulaElectoral);
            return await Save();
        }

        public async Task<bool> DeleteTaulaElectoral(TaulaElectoral taulaElectoral)
        {
            _context.Remove(taulaElectoral);
            return await Save();
        }

        public async Task<TaulaElectoral> GetTaulaElectoral(int id)
        {
            return await _context.TaulesElectorals.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<TaulaElectoral> GetTaulaElectoral(string name)
        {
            return await _context.TaulesElectorals.FirstOrDefaultAsync(c => c.NomTaula == name);
        }

        public async Task<ICollection<TaulaElectoral>> GetTaulesElectorals()
        {
            return await _context.TaulesElectorals.ToListAsync();
        }

		public async Task<List<TaulaElectoral>> GetTaulesElectoralsByMuniId(int muiniId)
		{
			return await _context.TaulesElectorals.Where(t=>t.MunicipiId == muiniId).ToListAsync();
		}

		public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false; 
        }

        public bool TaulaElectoralExists(int taulaElecId)
        {
            return  _context.TaulesElectorals.Any(c => c.ID == taulaElecId);
        }

        public async Task<bool> UpdateTaulaElectoral(TaulaElectoral taulaElectoral)
        {
            _context.Update(taulaElectoral);
            return await Save();
        }
    }
}
