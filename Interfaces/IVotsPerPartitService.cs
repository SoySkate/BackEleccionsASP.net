using BackEleccionsM.Dto;
using BackEleccionsM.Models;

namespace BackEleccionsM.Interfaces
{
    public interface IVotsPerPartitService
    {
        Task<ICollection<VotsPerPartitDto>> GetVotsPerPartits();
        Task<VotsPerPartitDto> GetVotsPerPartit(int id);
        Task<ICollection<VotsPerPartitDto>> GetVotsPerPartitsByResultatsTaulaID(int resultatsTaulaId);
		Task<ICollection<VotsPerPartitDto>> GetVotsPerPartitsByPartitID(int partitID);
		bool VotsPerPartitExists(int votsPerPartitId);
        Task<bool> CreateVotsPerPartit(VotsPerPartitDto votsPerPartit);
        Task<bool> UpdateVotsPerPartit(VotsPerPartitDto votsPerPartit);
        Task<bool> DeleteVotsPerPartit(int id);
    }
}
