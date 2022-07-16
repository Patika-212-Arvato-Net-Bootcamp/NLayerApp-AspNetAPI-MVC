using FluentValidation;
using NLayer.Core.DTOs.MoviesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
    public class MoviesDtoValidator : AbstractValidator<MoviesUpdateDtos>
    {
        public MoviesDtoValidator()
        {

            RuleFor(x => x.release_date).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.homepage).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
       


        }


    }
}
