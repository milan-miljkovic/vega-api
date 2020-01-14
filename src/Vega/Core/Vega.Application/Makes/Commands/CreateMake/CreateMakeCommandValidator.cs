using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Vega.Persistance;

namespace Vega.Application.Makes.Commands.CreateMake
{
    public class CreateMakeCommandValidator : AbstractValidator<CreateMakeCommand>
    {
        public CreateMakeCommandValidator(VegaDbContext dbContext)
        {
            RuleFor(m => m.Name)
                .MaximumLength(255)
                .NotEmpty()
                .CustomAsync(async (name, context, cancellationToken) =>
                {
                    var exist = (await dbContext.Makes
                        .CountAsync(m => m.Name.ToUpper() == name.ToUpper())
                        .ConfigureAwait(false)) == 1;

                    if (exist)
                    {
                        context.AddFailure($"Make with name '{name}' already exist");
                    }
                });
        }
    }
}
