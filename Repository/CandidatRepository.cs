using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEndEleccions.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEleccionsM.Repository
{

    //funciones que se usaran para acciones CRUD + interface(funciones declaradas)
    //el repository se intercomunica directamente con el context
    public class CandidatRepository : ICandidatRepository
    {
        private readonly DataContext _context;

        public CandidatRepository(DataContext context)
        {
            _context = context;
        }

        public bool CandidatExists(int catid)
        {
            return _context.Candidats.Any(c => c.ID == catid);
        }

        public async Task<bool> CreateCandidat(Candidat candidat)
        {
            _context.Add(candidat);
            return await Save();
        }

        public async Task<bool> DeleteCandidat(Candidat candidat)
        {
            _context.Remove(candidat);
            return await Save();
        }

        public async Task<Candidat> GetCandidat(int id)
        {
            return await _context.Candidats.FirstOrDefaultAsync(c=> c.ID == id);
        }

        public async Task<Candidat> GetCandidat(string name)
        {
            return await _context.Candidats.FirstOrDefaultAsync(c => c.NomCandidat == name);
        }

        public async Task<ICollection<Candidat>> GetCandidats()
        {
            return await _context.Candidats.ToListAsync();
        }

		public async Task<List<Candidat>> GetCandidatsByMunicipiId(int muniId)
		{
			return await _context.Candidats.Where(c=>c.PartitPolitic.MunicipiId == muniId).ToListAsync();
		}

		public async Task<List<Candidat>> GetCandidatsByPartitId(int partitId)
		{
			return await _context.Candidats.Where(c=>c.PartitPoliticId == partitId).ToListAsync();
		}

		public async Task<bool> Save()
        {
              var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateCandidat(Candidat candidat)
        {
            _context.Update(candidat);
            return await Save();
        }
    }
}
