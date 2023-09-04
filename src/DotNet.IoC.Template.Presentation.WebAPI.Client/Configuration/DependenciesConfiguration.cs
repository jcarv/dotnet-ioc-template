namespace DotNet.IoC.Template.Presentation.WebAPI.Client.Configuration
{
    using DotNet.IoC.Template.Infrastructure.CrossCutting.Settings;
    using DotNetIoCTemplateRestClient;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependenciesConfiguration
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services, AppSettings appSettings)
        {
            //services.AddHttpClient("DotNetIoCTemplateWebAPIClient", client =>
            //{
            //    client.BaseAddress = new Uri(appSettings.ApiSettings.Url);
            //});

            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(appSettings.ApiSettings.Url) });

            services.AddScoped<ICountryDataService, CountryDataService>();
            services.AddScoped<IPlayerDataService, PlayerDataService>();
            services.AddScoped<ITeamDataService, TeamDataService>();

            return services;
        }
    }
}
