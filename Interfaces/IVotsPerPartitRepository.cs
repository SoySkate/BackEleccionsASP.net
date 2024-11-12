using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface IVotsPerPartitRepository
    {
        Task<ICollection<VotsPerPartit>> GetVotsPerPartits();
        Task<VotsPerPartit> GetVotsPerPartit(int id);
        bool VotsPerPartitExists(int votsPerPartitId);
        Task<bool> CreateVotsPerPartit(VotsPerPartit votsPerPartit);
        Task<bool> UpdateVotsPerPartit(VotsPerPartit votsPerPartit);
        Task<bool> DeleteVotsPerPartit(VotsPerPartit votsPerPartit);
        Task<bool> Save();
    }
}
