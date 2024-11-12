using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface ITaulaElectoralRepository
    {
        Task<ICollection<TaulaElectoral>> GetTaulesElectorals();
        Task<TaulaElectoral> GetTaulaElectoral(int id);
        Task<TaulaElectoral> GetTaulaElectoral(string name);
        Task <List<TaulaElectoral>> GetTaulesElectoralsByMuniId(int muiniId);
        bool TaulaElectoralExists(int taulaElecId);
        Task<bool> CreateTaulaElectoral(TaulaElectoral taulaElectoral);
        Task<bool> UpdateTaulaElectoral(TaulaElectoral taulaElectoral);
        Task<bool> DeleteTaulaElectoral(TaulaElectoral taulaElectoral);
        Task<bool> Save();
    }
}
