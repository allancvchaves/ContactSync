using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IMockAPIService, MockAPIService>();

            services.AddScoped<IMailChimpService, MailChimpService>();
            services.AddScoped<IMockAPIService, MockAPIService>();

            return services;
        }
    }
}
