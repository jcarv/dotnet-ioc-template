namespace DotNet.IoC.Template.Data.EFCore.Configuration
{
    using DotNet.IoC.Template.Data.EFCore.Repositories;
    using DotNet.IoC.Template.Domain.Core;
    using DotNet.IoC.Template.Domain.Core.Repositories;
    using DotNet.IoC.Template.Infrastructure.CrossCutting.Settings;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependenciesConfiguration
    {
        public static IServiceCollection ConfigureDataEf(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(appSettings.DataBaseSettings.ConnectionString));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICountriesRepository, CountriesRepository>();
            services.AddTransient<IPlayersRepository, PlayersRepository>();
            services.AddTransient<ITeamsPlayersRepository, TeamsPlayersRepository>();
            services.AddTransient<ITeamsRepository, TeamsRepository>();

            return services;
        }
    }
}
