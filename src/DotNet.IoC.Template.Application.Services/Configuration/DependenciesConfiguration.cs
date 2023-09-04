namespace DotNet.IoC.Template.Application.Services.Configuration
{
    using DotNet.IoC.Template.Application.Services.Countries;
    using DotNet.IoC.Template.Application.Services.Players;
    using DotNet.IoC.Template.Application.Services.Teams;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependenciesConfiguration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamService, TeamService>();

            return services;
        }
    }
}
