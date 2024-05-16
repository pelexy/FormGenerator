using AutoMapper;
using FormBuilder.Modules.Core.Models;
using Function.Modules.Core;
using Modules.Form.Dto;
using Modules.Form.Models;

namespace Modules.Form
{
    public class FormMappingProfile : Profile
    {
        public FormMappingProfile(AppConstants appConstants)
        {

            CreateMap<ProgrammeDto, Programme>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
                    .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));

            CreateMap<UpdateProgrammeDto, Programme>()

       .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));

            CreateMap<Programme, ReadProgrammeDto>();
            CreateMap<PersonalnfoDto, PersonaInfo>()
                      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()));

            CreateMap<Question, ReadQuestionDto>()

       .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToObject()));

            CreateMap<QuestionDto, Question>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()));
        }
    }
}
