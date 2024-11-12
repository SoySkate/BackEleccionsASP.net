using AutoMapper;
using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEleccionsM.Repository;
using BackEndEleccions.Data;

namespace BackEleccionsM.Services
{
    public class MunicipiService : IMunicipiService
    {
        private readonly IMunicipiRepository _municipiRepository;
        private readonly IMapper _mapper;

        public MunicipiService(IMunicipiRepository municipiRepository, IMapper mapper)
        {
            _municipiRepository = municipiRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateMunicipi(MunicipiDto municipi)
        {
            var munis = await _municipiRepository.GetMunicipis();
            var muniExists = munis.Where(u => u.NomMunicipi.Trim().ToUpper() == municipi.NomMunicipi.Trim().ToUpper()).FirstOrDefault();
            if (muniExists != null) { return false; }
            else 
            {
                var muniMap = _mapper.Map<Municipi>(municipi);
                return await _municipiRepository.CreateMunicipi(muniMap);
            }
        }

        public async Task<bool> DeleteMunicipi(int id)
        {
            var muni = await _municipiRepository.GetMunicipi(id);
            if(muni == null) { return false; }
            else
            {
                var munimap = _mapper.Map <Municipi>(muni);
                return await _municipiRepository.DeleteMunicipi(munimap);
            }
        }

        public async Task<MunicipiDto> GetMunicipi(int id)
        {
            var muniExist = _municipiRepository.MunicipiExists(id);
            if (muniExist)
            {
                return _mapper.Map<MunicipiDto>(await _municipiRepository.GetMunicipi(id));
            }
            return null;
        }

        public async Task<MunicipiDto> GetMunicipi(string name)
        {
            var muniExist = _municipiRepository.GetMunicipi(name);
            if (muniExist!=null)
            {
                return _mapper.Map<MunicipiDto>(await _municipiRepository.GetMunicipi(name));
            }
            return null;
        }

        public async Task<ICollection<MunicipiDto>> GetMunicipis()
        {
            return _mapper.Map<List<MunicipiDto>>(await _municipiRepository.GetMunicipis());    
        }

        public bool MunicipiExists(int municipiId)
        {
            return _municipiRepository.MunicipiExists(municipiId);
        }

        public async Task<bool> UpdateMunicipi(MunicipiDto municipi)
        {
            var munis = _municipiRepository.MunicipiExists(municipi.ID);
            if (munis) 
            {
                var muniF = await _municipiRepository.GetMunicipi(municipi.ID);
                var muniMap = _mapper.Map(municipi, muniF);

                return await _municipiRepository.UpdateMunicipi(muniMap);
            }
          return false;
        }
    }
}
