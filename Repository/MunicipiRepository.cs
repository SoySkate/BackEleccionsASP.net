using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEndEleccions.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEleccionsM.Repository
{
    public class MunicipiRepository : IMunicipiRepository
    {
        private readonly DataContext _context;

        public MunicipiRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMunicipi(Municipi municipi)
        {
            _context.Add(municipi);
            return await Save();
        }

        public async Task<bool> DeleteMunicipi(Municipi municipi)
        {
            _context.Remove(municipi);
            return await Save();
        }

        public async Task<Municipi> GetMunicipi(int id)
        {
            return await _context.Municipis.FirstOrDefaultAsync(m=>m.ID==id);
        }

        public async Task<Municipi> GetMunicipi(string name)
        {
            return await _context.Municipis.FirstOrDefaultAsync(m => m.NomMunicipi == name);
        }

        public async Task<ICollection<Municipi>> GetMunicipis()
        {
            return await _context.Municipis.ToListAsync();
        }

        public bool MunicipiExists(int municipiId)
        {
            return  _context.Municipis.Any(m => m.ID == municipiId);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateMunicipi(Municipi municipi)
        {
            _context.Update(municipi);
            return await Save();
        }
    }
}
