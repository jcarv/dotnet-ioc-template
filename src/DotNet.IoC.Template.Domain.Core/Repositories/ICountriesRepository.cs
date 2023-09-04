namespace DotNet.IoC.Template.Domain.Core.Repositories
{
    using DotNet.IoC.Template.Domain.Models;

    public interface ICountriesRepository
    {
        Task<Country> FindAsync(int id);

        Task<Country> FindByNameAliasAsync(string name);

        Task<List<Country>> GetAllAsync();

        void Insert(Country country);

        void Update(Country country);

        void Delete(Country country);
    }
}
