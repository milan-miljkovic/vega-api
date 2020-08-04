using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vega.Application.Models.Queries.GetModel
{
    class GetModelQueryValidator : AbstractValidator<GetModelQuery>
    {
        public GetModelQueryValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
        }
    }
}
