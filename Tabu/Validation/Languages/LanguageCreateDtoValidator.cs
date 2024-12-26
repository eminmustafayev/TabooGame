using FluentValidation;
using Tabu.DTOs.Languages;

namespace Tabu.Validation.Languages
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x=>x.Code)
                .NotEmpty()
                    .WithMessage("Ad bosh ola bilmez")
                .NotNull()
                    .WithMessage("Ad null ola bilmez")
                .Length(2)
                    .WithMessage("Ad uzunlugu 2den uzun ola bilmez");
            RuleFor(x => x.Name)
                .MaximumLength(32)
                .MinimumLength(3);

            RuleFor(x => x.IconUrl)
                .MaximumLength (128)
                .Matches("^http(s) ?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                    .WithMessage("link daxil edin z.o");
        }
        
         
    }
}
