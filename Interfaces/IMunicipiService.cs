using BackEleccionsM.Dto;
using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface IMunicipiService
    {
        Task<ICollection<MunicipiDto>> GetMunicipis();
        Task<MunicipiDto> GetMunicipi(int id);
        Task<MunicipiDto> GetMunicipi(string name);
        bool MunicipiExists(int municipiId);
        Task<bool> CreateMunicipi(MunicipiDto municipi);
        Task<bool> UpdateMunicipi(MunicipiDto municipi);
        Task<bool> DeleteMunicipi(int id);
    }
}
