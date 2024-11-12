using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface IMunicipiRepository
    {
        Task<ICollection<Municipi>> GetMunicipis();
        Task<Municipi> GetMunicipi(int id);
        Task<Municipi> GetMunicipi(string name);
        bool MunicipiExists(int municipiId);
        Task<bool> CreateMunicipi(Municipi municipi);
        Task<bool> UpdateMunicipi(Municipi municipi);
        Task<bool> DeleteMunicipi(Municipi municipi);
        Task<bool> Save();
    }
}
