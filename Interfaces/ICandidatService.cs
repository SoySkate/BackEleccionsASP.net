using BackEleccionsM.Dto;
using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface ICandidatService
    {
        Task<ICollection<CandidatDto>> GetCandidats();
        Task<CandidatDto> GetCandidat(int id);
        Task<CandidatDto> GetCandidat(string name);
		Task<List<CandidatDto>> GetCandidatsByPartitId(int partitId);

		bool CandidatExists(int id);
        Task<bool> CreateCandidat(CandidatDto candidat);
        Task<bool> UpdateCandidat(CandidatDto candidat);
        Task<bool> DeleteCandidat(int id);
    }
}
