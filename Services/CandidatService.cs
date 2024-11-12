using AutoMapper;
using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEndEleccions.Data;

namespace BackEleccionsM.Services
{
    //Aqui el Service lo que hace es tener la logica del programa 
    //Se connecta al repositorio y hace las funciones lgicas necesarias Repo-Service-Controller
    public class CandidatService : ICandidatService
    {
        private readonly ICandidatRepository _candidatRepository;
        private readonly IMapper _mapper;

        public CandidatService(ICandidatRepository candidatRepository, IMapper mapper)
        {
            _candidatRepository = candidatRepository;
            _mapper = mapper;
        }

        public bool CandidatExists(int id)
        {
            return _candidatRepository.CandidatExists(id);
        }

        public async Task<bool> CreateCandidat(CandidatDto candidat)
        {
            var cand = await _candidatRepository.GetCandidats();
            var candExist = cand.Where(c=> c.NomCandidat.Trim().ToUpper() == candidat.NomCandidat.Trim().ToUpper()).FirstOrDefault();
            if (candExist != null) { return false; } 
            else {
                //mapea candidatDto a candidat
                var candMap = _mapper.Map<Candidat>(candidat);
                //crea candidato en el repo
            return await _candidatRepository.CreateCandidat(candMap);
            }
        }

        public async Task<bool> DeleteCandidat(int id)
        {
            var cand = await _candidatRepository.GetCandidat(id);
           
            if (cand == null) { return false; }
            else
            {
                //mapea candidatDto a candidat
                var candMap = _mapper.Map<Candidat>(cand);
                //crea candidato en el repo
                return await _candidatRepository.DeleteCandidat(candMap);
            }
        }

        public async Task<CandidatDto> GetCandidat(int id)
        {
            var candExist =  _candidatRepository.CandidatExists(id);
            if (candExist)
            {
                return _mapper.Map<CandidatDto>(await _candidatRepository.GetCandidat(id));
            }
            return null;
        }

        public async Task<CandidatDto> GetCandidat(string name)
        {
            var candExist = _candidatRepository.GetCandidat(name);
            if (candExist!=null)
            {
                return _mapper.Map<CandidatDto>(await _candidatRepository.GetCandidat(name));
            }
            return null;
        }

        public async Task<ICollection<CandidatDto>> GetCandidats()
        {
            return _mapper.Map<List<CandidatDto>>(await _candidatRepository.GetCandidats());
        }

		public async Task<List<CandidatDto>> GetCandidatsByPartitId(int partitId)
		{
            return _mapper.Map<List<CandidatDto>>(await _candidatRepository.GetCandidatsByPartitId(partitId));
		}

		public async Task<bool> UpdateCandidat(CandidatDto candidat)
        {
            var cand = _candidatRepository.CandidatExists(candidat.ID);

            if (cand)
            {
                var currentcand = await _candidatRepository.GetCandidat(candidat.ID);
                //mapea candidatDto a candidat
                var candMap = _mapper.Map(candidat, currentcand);
                //crea candidato en el repo
                return await _candidatRepository.UpdateCandidat(candMap);
            }
            else
            {
                return false;
            }
        }
    }
}
