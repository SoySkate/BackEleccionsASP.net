using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface IPartitPoliticRepository
    {
        Task<ICollection<PartitPolitic>> GetPartitsPolitics();
        Task<PartitPolitic> GetPartitPolitic(int id);
        Task<PartitPolitic> GetPartitPolitic(string name);
        Task<ICollection<PartitPolitic>> GetPartitsPoliticsByMuniID(int muniID);
        bool PartitPoliticExists(int partitId);
        Task<bool> CreatePartitPolitic(PartitPolitic partitPolitic);
        Task<bool> UpdatePartitPolitic(PartitPolitic partitPolitic);
        Task<bool> DeletePartitPolitic(PartitPolitic partitPolitic);
        Task<bool> Save();
    }
}
