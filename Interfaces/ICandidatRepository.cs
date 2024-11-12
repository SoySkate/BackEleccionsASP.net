using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{

    //funciones que hara el repository /(DatabaseAcces)
    //La interface implementa directamente el repository
    public interface ICandidatRepository
    {
        Task<ICollection<Candidat>> GetCandidats();
        Task<Candidat> GetCandidat(int id);
        Task<Candidat> GetCandidat(string name);
        Task <List<Candidat>> GetCandidatsByPartitId(int partitId);
        bool CandidatExists(int id);
        Task<bool> CreateCandidat(Candidat candidat);
        Task<bool> UpdateCandidat(Candidat candidat);
        Task<bool> DeleteCandidat(Candidat candidat);
        Task<bool> Save();
    }
}
