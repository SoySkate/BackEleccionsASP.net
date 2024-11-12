using AutoMapper;
using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEleccionsM.Repository;
using BackEndEleccions.Data;

namespace BackEleccionsM.Services
{
    public class VotsPerPartitService : IVotsPerPartitService
    {
        private readonly IVotsPerPartitRepository _votsPerPartitRepository;
        private readonly IMapper _mapper;

        public VotsPerPartitService(IVotsPerPartitRepository votsPerPartitRepository, IMapper mapper)
        {
            _votsPerPartitRepository = votsPerPartitRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateVotsPerPartit(VotsPerPartitDto votsPerPartit)
        {
            var vots = await _votsPerPartitRepository.GetVotsPerPartits();
            var votExist = vots.Where(v => v.ID == votsPerPartit.ID).FirstOrDefault();
            if(votExist != null) { return false; }
            else
            {
                var votMap = _mapper.Map<VotsPerPartit>(votsPerPartit);
                return await _votsPerPartitRepository.CreateVotsPerPartit(votMap);
            }
        }

        public async Task<bool> DeleteVotsPerPartit(int id)
        {
            var votExist = _votsPerPartitRepository.VotsPerPartitExists(id);
            if (votExist == false) { return false; }
            else
            {
                var vot = await _votsPerPartitRepository.GetVotsPerPartit(id);
                return await _votsPerPartitRepository.DeleteVotsPerPartit(vot);
            }
        }

        public async Task<VotsPerPartitDto> GetVotsPerPartit(int id)
        {
            var votExist = _votsPerPartitRepository.VotsPerPartitExists(id);
            if (votExist == false) { return null; }
            else
            {
                return _mapper.Map<VotsPerPartitDto>(await _votsPerPartitRepository.GetVotsPerPartit(id));
            }
        }

        public async Task<ICollection<VotsPerPartitDto>> GetVotsPerPartits()
        {
            return _mapper.Map<List<VotsPerPartitDto>>(await _votsPerPartitRepository.GetVotsPerPartits());
        }

        public async Task<bool> UpdateVotsPerPartit(VotsPerPartitDto votsPerPartit)
        {

            var vots = await _votsPerPartitRepository.GetVotsPerPartits();
            var votExist = vots.Where(v => v.ID == votsPerPartit.ID).FirstOrDefault();
            if (votExist == null) { return false; }
            else
            {
                var vot = await _votsPerPartitRepository.GetVotsPerPartit(votsPerPartit.ID);
                var votMap = _mapper.Map(votsPerPartit, vot);
                return await _votsPerPartitRepository.UpdateVotsPerPartit(votMap);
            }
        }

        public bool VotsPerPartitExists(int votsPerPartitId)
        {
           return _votsPerPartitRepository.VotsPerPartitExists(votsPerPartitId);
        }
    }
}
