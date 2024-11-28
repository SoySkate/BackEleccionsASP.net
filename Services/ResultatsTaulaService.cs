using AutoMapper;
using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEleccionsM.Repository;
using BackEndEleccions.Data;

namespace BackEleccionsM.Services
{
    public class ResultatsTaulaService : IResultatsTaulaService
    {
        private readonly IResultatsTaulaRepository _resultatsTaulaRepository;
        private readonly IMapper _mapper;

        public ResultatsTaulaService(IResultatsTaulaRepository resultatsTaulaRepository, IMapper mapper)
        {
            _resultatsTaulaRepository = resultatsTaulaRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateResultatsTaula(ResultatsTaulaDto resultatsTaula)
        {
            var result = await _resultatsTaulaRepository.GetResultatsTaules();
            var resultExists = _resultatsTaulaRepository.ResultatsTaulaExists(resultatsTaula.ID);
            if (resultExists) { return false; }
            else
            {
                var resultMap = _mapper.Map<ResultatsTaula>(resultatsTaula);
                return await _resultatsTaulaRepository.CreateResultatsTaula(resultMap);   
            }
        }

        public async Task<bool> DeleteResultatsTaula(int id)
        {
            var resExist= _resultatsTaulaRepository.ResultatsTaulaExists(id);
            if (resExist) 
            {
                var Rtaula = _mapper.Map<ResultatsTaula>(await _resultatsTaulaRepository.GetResultatsTaula(id));
                return await _resultatsTaulaRepository.DeleteResultatsTaula(Rtaula);
            }
            else { return false; }
        }

        public async Task<ResultatsTaulaDto> GetResultatsTaula(int id)
        {
            var resExist = _resultatsTaulaRepository.ResultatsTaulaExists(id);
            if (resExist)
            {
                var resuMap = _mapper.Map<ResultatsTaulaDto>(await _resultatsTaulaRepository.GetResultatsTaula(id));
                return resuMap;
            }
            else {  return null; }
        }

        public async Task<ResultatsTaulaDto> GetResultatsTaulaByTaulaID(int id)
        {
            var result = _mapper.Map<ResultatsTaulaDto>(await _resultatsTaulaRepository.GetResultatsTaulaByTaulaID(id));
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<ICollection<ResultatsTaulaDto>> GetResultatsTaules()
        {
            return _mapper.Map<List<ResultatsTaulaDto>>(await _resultatsTaulaRepository.GetResultatsTaules());
        }

        public bool ResultatsTaulaExists(int resultatTaulaId)
        {
            return _resultatsTaulaRepository.ResultatsTaulaExists(resultatTaulaId);
        }

        public async Task<bool> UpdateResultatsTaula(ResultatsTaulaDto resultatsTaula)
        {
            var resultExists = _resultatsTaulaRepository.ResultatsTaulaExists(resultatsTaula.ID);
            if (resultExists)
            {
                var res = await _resultatsTaulaRepository.GetResultatsTaula(resultatsTaula.ID);
                var resultMap = _mapper.Map(resultatsTaula, res);
                return await _resultatsTaulaRepository.UpdateResultatsTaula(resultMap);
            }
            else { return false; }
        }
    }
}
