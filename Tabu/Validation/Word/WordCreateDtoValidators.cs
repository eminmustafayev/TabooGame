using FluentValidation;
using Tabu.DTOs.Word;

namespace Tabu.Validation
{
    public class WordCreateDtoValidation:AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidation()
        {
            RuleForEach(x => x.BannedWords)
                    .NotNull()
                    .MinimumLength(2);
            RuleFor(x => x.BannedWords)
                .NotNull()
                .Must(x => x.Count == 6);

        }
    }
}
