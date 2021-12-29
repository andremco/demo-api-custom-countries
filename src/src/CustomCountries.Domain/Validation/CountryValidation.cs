using CustomCountries.Domain.Models.Country;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomCountries.Domain.Validation
{
    public class CountryValidation : AbstractValidator<Country>
    {
        public CountryValidation()
        {

            RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Name must not be empty!");

            RuleFor(x => x.Native)
                    .NotEmpty()
                    .WithMessage("Native must not be empty!");

            RuleFor(x => x.Capital)
                    .NotEmpty()
                    .WithMessage("Capital must not be empty!");

            RuleFor(x => x.Emoji)
                .NotEmpty()
                .WithMessage("Emoji must not be empty!");

            RuleFor(x => x.Currency)
                .NotEmpty()
                .WithMessage("Currency must not be empty!");

            RuleFor(x => x.Languages)
                .NotEmpty()
                .WithMessage("Languages must not be empty!");
        }
    }
}
