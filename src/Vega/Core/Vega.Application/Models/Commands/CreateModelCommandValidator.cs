using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vega.Persistance;

namespace Vega.Application.Models.Commands
{
    public class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
    {
        public CreateModelCommandValidator(VegaDbContext dbContext)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(m => m.Name)
                .MaximumLength(255)
                .NotEmpty()
                .CustomAsync(async (name, context, cancellationToken) =>
                {
                    var exist = (await dbContext.Models
                        .CountAsync(m => m.Name.ToUpper() == name.ToUpper(), cancellationToken)
                        .ConfigureAwait(false)) == 1;

                    if (exist)
                    {
                        context.AddFailure($"Model with name '{name}' already exist");
                    }
                });
            RuleFor(m => m.MakeId)
                .NotEmpty()
                .Custom((makeId, context) =>
                {
                    if (!Guid.TryParse(makeId, out Guid _))
                    {
                        context.AddFailure($"Provided value for make ID '{makeId}' is not valid");
                    }
                })
                .CustomAsync(async (makeId, context, cancellationToken) =>
                {
                    var exist = (await dbContext.Makes
                        .CountAsync(m => m.Id == new Guid(makeId), cancellationToken)
                        .ConfigureAwait(false)) == 1;
                    if (!exist)
                    {
                        context.AddFailure($"Make with given ID '{makeId}' doesn't exist");
                    }
                });
        }
    }
}
