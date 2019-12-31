using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vega.Application.Makes.Commands.CreateMake
{
    class MakeNameValidator : IPropertyValidator
    {
        public PropertyValidatorOptions Options => throw new NotImplementedException();

        public bool ShouldValidateAsync(ValidationContext context)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationFailure> Validate(PropertyValidatorContext context)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ValidationFailure>> ValidateAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
