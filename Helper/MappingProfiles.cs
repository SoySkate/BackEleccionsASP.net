using AutoMapper;
using BackEleccionsM.Dto;
using BackEleccionsM.Models;

namespace BackEleccionsM.Helper
{
    //Aqui podemos especificar como se hacen los mapeos (de una class a otra classDto y a la inversa)
    //Osea de que forma mapeamos (especificaciones)
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //se puede hacer asi tambien: con el .reverse()
            CreateMap<Candidat, CandidatDto>()
                .ForMember(dest=>dest.PartitPoliticId, opt=>opt.MapFrom(src=>src.PartitPoliticId));
            CreateMap<CandidatDto, Candidat>()
                .ForMember(dest=>dest.PartitPolitic, opt=>opt.Ignore())
                .ForMember(dest=>dest.PartitPoliticId, opt=>opt.MapFrom(src=>src.PartitPoliticId));


            CreateMap<Municipi, MunicipiDto>();
            CreateMap<MunicipiDto, Municipi>();

            CreateMap<PartitPolitic, PartitPoliticDto>()
                .ForMember(dest=>dest.MunicipiId, opt=>opt.MapFrom(src => src.MunicipiId));
            CreateMap<PartitPoliticDto, PartitPolitic>()
                .ForMember(dest => dest.Municipi, opt => opt.Ignore())
                .ForMember(dest => dest.MunicipiId, opt => opt.MapFrom(src => src.MunicipiId));

            CreateMap<ResultatsTaula, ResultatsTaulaDto>()
                .ForMember(dest=>dest.TaulaElectoralId, opt=>opt.MapFrom(src=>src.TaulaElectoralId));
            CreateMap<ResultatsTaulaDto, ResultatsTaula>()
                .ForMember(dest=>dest.TaulaElectoralId, opt=>opt.MapFrom(src=>src.TaulaElectoralId));

            CreateMap<TaulaElectoral, TaulaElectoralDto>()
                  .ForMember(dest => dest.MunicipiId, opt => opt.MapFrom(src => src.MunicipiId));
            CreateMap<TaulaElectoralDto, TaulaElectoral>()
                .ForMember(dest => dest.Municipi, opt => opt.Ignore())
                .ForMember(dest => dest.MunicipiId, opt => opt.MapFrom(src => src.MunicipiId));

            CreateMap<VotsPerPartit, VotsPerPartitDto>()
                .ForMember(dest=>dest.PartitId, opt=>opt.MapFrom(src=>src.PartitId))
                .ForMember(dest=>dest.ResultatsTaulaId, opt=>opt.MapFrom(src=>src.ResultatsTaulaId));
            CreateMap<VotsPerPartitDto, VotsPerPartit>()
                .ForMember(dest=>dest.Partit, opt=>opt.Ignore())
                .ForMember(dest=>dest.ResultatsTaula, opt=>opt.Ignore())
                .ForMember(dest=>dest.ResultatsTaulaId, opt=>opt.MapFrom(src=>src.ResultatsTaulaId))
                .ForMember(dest=>dest.PartitId, opt=>opt.MapFrom(src=>src.PartitId));

            // Mapear propiedades de colección dentro de Municipi y MunicipiDto
            //CreateMap<ICollection<PartitPolitic>, ICollection<PartitPoliticDto>>().ReverseMap();
            //CreateMap<ICollection<TaulaElectoral>, ICollection<TaulaElectoralDto>>().ReverseMap();
        }
    }
}
