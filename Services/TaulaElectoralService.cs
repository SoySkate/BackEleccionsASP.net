using AutoMapper;
using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEleccionsM.Repository;
using BackEndEleccions.Data;

namespace BackEleccionsM.Services
{
    public class TaulaElectoralService : ITaulaElectoralService
    {
        private readonly ITaulaElectoralRepository _taulaElectoralRepository;
        private readonly IMapper _mapper;

        public TaulaElectoralService(ITaulaElectoralRepository taulaElectoralRepository, IMapper mapper)
        {
            _taulaElectoralRepository = taulaElectoralRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateTaulaElectoral(TaulaElectoralDto taulaElectoral)
        {
            var taules = await _taulaElectoralRepository.GetTaulesElectorals();
            var taulaExist = taules.Where(t => t.NomTaula.Trim().ToUpper() == taulaElectoral.NomTaula.Trim().ToUpper()).FirstOrDefault();
            if(taulaExist != null) { return false; }
            else
            {
                var taulaMap = _mapper.Map<TaulaElectoral>(taulaElectoral);
                return await _taulaElectoralRepository.CreateTaulaElectoral(taulaMap);
            }
        }

        public async Task<bool> DeleteTaulaElectoral(int id)
        {
            var taulaExist = _taulaElectoralRepository.TaulaElectoralExists(id);
            if (taulaExist == false) { return false; }
            else
            {
                var taula = await _taulaElectoralRepository.GetTaulaElectoral(id);
                return await _taulaElectoralRepository.DeleteTaulaElectoral(taula);
            }
        }

        public async Task<TaulaElectoralDto> GetTaulaElectoral(int id)
        {
            var taulaExist = _taulaElectoralRepository.TaulaElectoralExists(id);
            if (taulaExist == false) { return null; }
            else
            {
                return _mapper.Map<TaulaElectoralDto>(await _taulaElectoralRepository.GetTaulaElectoral(id));  
            }
        }

        public async Task<TaulaElectoralDto> GetTaulaElectoral(string name)
        {
            var taules = await _taulaElectoralRepository.GetTaulesElectorals();
            var taulaExist = taules.Where(t => t.NomTaula == name);
            if (taulaExist == null) { return null; }
            else
            {
               return _mapper.Map<TaulaElectoralDto>(taulaExist);
            }
        }

        public async Task<ICollection<TaulaElectoralDto>> GetTaulesElectorals()
        {
            return _mapper.Map<List<TaulaElectoralDto>>(await _taulaElectoralRepository.GetTaulesElectorals());
        }

		public async Task<List<TaulaElectoralDto>> GetTaulesElectoralsByMuniId(int muniId)
		{
            return _mapper.Map<List<TaulaElectoralDto>>(await _taulaElectoralRepository.GetTaulesElectoralsByMuniId(muniId));
		}

		public bool TaulaElectoralExists(int taulaElecId)
        {
            return _taulaElectoralRepository.TaulaElectoralExists(taulaElecId);
        }

        public async Task<bool> UpdateTaulaElectoral(TaulaElectoralDto taulaElectoral)
        {
            var taulaExist = _taulaElectoralRepository.TaulaElectoralExists(taulaElectoral.ID);
            if (taulaExist == false) { return false; }
            else
            {
                var taula = await _taulaElectoralRepository.GetTaulaElectoral(taulaElectoral.ID);
                var taulaMap = _mapper.Map(taulaElectoral, taula);
                return await _taulaElectoralRepository.UpdateTaulaElectoral(taulaMap);
            }
        }
    }
}
