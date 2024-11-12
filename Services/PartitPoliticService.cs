using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEleccionsM.Repository;
using BackEndEleccions.Data;

namespace BackEleccionsM.Services
{
    public class PartitPoliticService : IPartitPoliticService
    {
        private readonly IPartitPoliticRepository _partitPoliticRepository;
        private readonly IMapper _mapper;

        public PartitPoliticService(IPartitPoliticRepository partitPoliticRepository, IMapper mapper)
        {
            _partitPoliticRepository = partitPoliticRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreatePartitPolitic(PartitPoliticDto partitPolitic)
        {
            var partits = await _partitPoliticRepository.GetPartitsPolitics();
            var partitExists = partits.Where(p => p.NomPartit.Trim().ToUpper() == partitPolitic.NomPartit.Trim().ToUpper()).FirstOrDefault();
            if (partitExists != null) { return false; } 
            else
            {
                var partitMap = _mapper.Map<PartitPolitic>(partitPolitic);
                return await _partitPoliticRepository.CreatePartitPolitic(partitMap);
            }
        }

        public async Task<bool> DeletePartitPolitic(int id)
        {
            var partit = await _partitPoliticRepository.GetPartitPolitic(id);
            if (partit == null) {  return false; }
            else
            {
                var partitMap = _mapper.Map<PartitPolitic>(partit);
                return await _partitPoliticRepository.DeletePartitPolitic(partitMap);
            }
        }

        public async Task<PartitPoliticDto> GetPartitPolitic(int id)
        {
            var partitExists = _partitPoliticRepository.PartitPoliticExists(id);
            if (partitExists)
            {
                return _mapper.Map<PartitPoliticDto>(await _partitPoliticRepository.GetPartitPolitic(id));
            }
            return null;
        }

        public async Task<PartitPoliticDto> GetPartitPolitic(string name)
        {
            var partitExists = _partitPoliticRepository.GetPartitPolitic(name);
            if (partitExists!=null)
            {
                return _mapper.Map<PartitPoliticDto>(await _partitPoliticRepository.GetPartitPolitic(name));
            }
            return null;
        }

		public async Task<ICollection<PartitPoliticDto>> GetPartitsPoliticsByMuniID(int muniID)
		{
			return _mapper.Map<List<PartitPoliticDto>>(await _partitPoliticRepository.GetPartitsPoliticsByMuniID(muniID));
		}

		public async Task<ICollection<PartitPoliticDto>> GetPartitsPolitics()
        {
            return _mapper.Map<List<PartitPoliticDto>>(await _partitPoliticRepository.GetPartitsPolitics());
        }

        public bool PartitPoliticExists(int partitId)
        {
            return _partitPoliticRepository.PartitPoliticExists(partitId);
        }

        public async Task<bool> UpdatePartitPolitic(PartitPoliticDto partitPolitic)
        {

            var partitExists = _partitPoliticRepository.PartitPoliticExists(partitPolitic.ID);
            if (partitExists) 
            {
                var partit = await _partitPoliticRepository.GetPartitPolitic(partitPolitic.ID);
                var partitMap = _mapper.Map(partitPolitic, partit);
                

                return await _partitPoliticRepository.UpdatePartitPolitic(partitMap);
            }
            else
            {
                return false;
            }
        }
    }
}
