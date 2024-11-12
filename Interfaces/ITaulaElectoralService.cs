using BackEleccionsM.Dto;
using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface ITaulaElectoralService
    {
        Task<ICollection<TaulaElectoralDto>> GetTaulesElectorals();
        Task<TaulaElectoralDto> GetTaulaElectoral(int id);
        Task<TaulaElectoralDto> GetTaulaElectoral(string name);
		Task<List<TaulaElectoralDto>> GetTaulesElectoralsByMuniId(int muniId);
		bool TaulaElectoralExists(int taulaElecId);
        Task<bool> CreateTaulaElectoral(TaulaElectoralDto taulaElectoral);
        Task<bool> UpdateTaulaElectoral(TaulaElectoralDto taulaElectoral);
        Task<bool> DeleteTaulaElectoral(int id);
    }
}
