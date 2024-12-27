using AutoMapper;
using Tabu.DTOs.Languages;
using Tabu.Entities;

namespace Tabu.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>();
            CreateMap< Language , LanguageGeetDto>();
        }
    }
}
    