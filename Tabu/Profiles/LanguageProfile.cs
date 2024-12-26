using AutoMapper;
using Tabu.DTOs.Languages;
using Tabu.Entities;

namespace Tabu.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>()
                .ForMember(l=>l.IconUrl, lcd=>lcd.MapFrom(x=>x.IconUrl));
            CreateMap< Language , LanguageGeetDto>();
        }
    }
}
    