namespace DotNet.IoC.Template.Data.EFCore.Repositories
{
    using DotNet.IoC.Template.Domain.Core.Repositories;
    using DotNet.IoC.Template.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    internal class CountriesRepository : ICountriesRepository
    {
        private AppDbContext _context;

        public CountriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Country> FindAsync(int id)
        {
            return _context.Countries
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<Country> FindByNameAliasAsync(string name)
        {
            return _context.Countries
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.NameAlias == name);
        }

        public Task<List<Country>> GetAllAsync()
        {
            return _context.Countries
                .AsNoTracking()
                .ToListAsync();
        }

        public void Insert(Country country)
        {

            _context.Entry(country).State = EntityState.Added;
        }

        public void Update(Country country)
        {
            _context.Entry(country).State = EntityState.Modified;
        }

        public void Delete(Country country)
        {
            _context.Entry(country).State = EntityState.Deleted;
        }
    }
}
