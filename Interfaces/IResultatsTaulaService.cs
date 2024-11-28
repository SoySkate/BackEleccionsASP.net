using BackEleccionsM.Dto;
using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface IResultatsTaulaService
    {
        Task<ICollection<ResultatsTaulaDto>> GetResultatsTaules();
        Task<ResultatsTaulaDto> GetResultatsTaula(int id);
        Task<ResultatsTaulaDto> GetResultatsTaulaByTaulaID(int id);
        bool ResultatsTaulaExists(int resultatTaulaId);
        Task<bool> CreateResultatsTaula(ResultatsTaulaDto resultatsTaula);
        Task<bool> UpdateResultatsTaula(ResultatsTaulaDto resultatsTaula);
        Task<bool> DeleteResultatsTaula(int id);
    }
}
