using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vega.Application.Makes.Queries.GetMake
{
    public class GetMakeQueryValidator : AbstractValidator<GetMakeQuery>
    {
        public GetMakeQueryValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
        }
    }
}
