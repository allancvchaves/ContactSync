using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection RegisterMailChimpService(this IServiceCollection services)
        {
            services.AddScoped<IMailChimpService, MailChimpService>();

            return services;
        }
    }
}
