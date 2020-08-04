using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vega.Application.Common.Behaviours;

namespace Vega.Application
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationServiceExtensions).Assembly);
            services.AddMediatR(typeof(ApplicationServiceExtensions).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }
    }
}
