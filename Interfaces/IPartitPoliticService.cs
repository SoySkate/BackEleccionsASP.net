using BackEleccionsM.Dto;
using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface IPartitPoliticService
    {
        Task<ICollection<PartitPoliticDto>> GetPartitsPolitics();
        Task<PartitPoliticDto> GetPartitPolitic(int id);
        Task<PartitPoliticDto> GetPartitPolitic(string name);
		Task<ICollection<PartitPoliticDto>> GetPartitsPoliticsByMuniID(int muniID);
		bool PartitPoliticExists(int partitId);
        Task<bool> CreatePartitPolitic(PartitPoliticDto partitPolitic);
        Task<bool> UpdatePartitPolitic(PartitPoliticDto partitPolitic);
        Task<bool> DeletePartitPolitic(int id);
    }
}
