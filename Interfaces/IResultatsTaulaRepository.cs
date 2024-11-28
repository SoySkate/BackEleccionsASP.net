using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface IResultatsTaulaRepository
    {
        Task<ICollection<ResultatsTaula>> GetResultatsTaules();
        Task<ResultatsTaula> GetResultatsTaula(int id);
        Task<ResultatsTaula> GetResultatsTaulaByTaulaID(int id);
        bool ResultatsTaulaExists(int resultatTaulaId);
        Task<bool> CreateResultatsTaula(ResultatsTaula resultatsTaula);
        Task<bool> UpdateResultatsTaula(ResultatsTaula resultatsTaula);
        Task<bool> DeleteResultatsTaula(ResultatsTaula resultatsTaula);
        Task<bool> Save();
    }
}
