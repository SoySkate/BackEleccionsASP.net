using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEndEleccions.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEleccionsM.Repository
{
    public class ResultatsTaulaRepository : IResultatsTaulaRepository
    {
        private readonly DataContext _context;

        public ResultatsTaulaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateResultatsTaula(ResultatsTaula resultatsTaula)
        {
            _context.Add(resultatsTaula);
            return await Save();
        }

        public async Task<bool> DeleteResultatsTaula(ResultatsTaula resultatsTaula)
        {
            _context.Remove(resultatsTaula);
            return await Save();
        }

        public async Task<ResultatsTaula> GetResultatsTaula(int id)
        {
            return await _context.ResultatsTaules.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<ResultatsTaula> GetResultatsTaulaByTaulaID(int id)
        {
            return await _context.ResultatsTaules.Where(r=>r.TaulaElectoralId == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<ResultatsTaula>> GetResultatsTaules()
        {
            return await _context.ResultatsTaules.ToListAsync();
        }

        public bool ResultatsTaulaExists(int resultatTaulaId)
        {
            return  _context.ResultatsTaules.Any(c => c.ID == resultatTaulaId);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateResultatsTaula(ResultatsTaula resultatsTaula)
        {
            _context.Update(resultatsTaula);
            return await Save();
        }
    }
}
