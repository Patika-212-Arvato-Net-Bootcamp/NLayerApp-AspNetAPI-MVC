using FluentValidation;
using NLayer.Core.DTOs.Genres;

namespace NLayer.Service.Validations
{
    public class GenreDtoValidator : AbstractValidator<GenresDto>
    {
        public GenreDtoValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");


        }


    }
}
