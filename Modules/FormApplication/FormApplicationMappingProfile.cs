using AutoMapper;
using FormBuilder.Modules.Core.Models;
using Function.Modules.Core;
using Modules.FormApplication.Dtos;
using Modules.FormApplication.Models;

namespace Modules.FormApplication
{
    public class FormMappingApplicationProfile : Profile
    {
        public FormMappingApplicationProfile(AppConstants appConstants)
        {

            CreateMap<ApplicationDto, Application>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()));

            CreateMap<ApplicationQuestionDto, ApplicationQuestion>();



            CreateMap<Application, ReadApplicationDto>();


            CreateMap<ApplicationQuestion, ReadApplicationQuestionDto>()

       .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToObject()));


        }
    }
}