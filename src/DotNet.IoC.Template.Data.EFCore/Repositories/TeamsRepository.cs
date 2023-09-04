namespace DotNet.IoC.Template.Data.EFCore.Repositories
{
    using DotNet.IoC.Template.Domain.Core.Repositories;
    using DotNet.IoC.Template.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class TeamsRepository : ITeamsRepository
    {
        private AppDbContext _context;

        public TeamsRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Team> FindAsync(int id)
        {
            return _context.Teams
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<Team> FindByNameAliasAsync(string name)
        {
            return _context.Teams
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.NameAlias == name);
        }

        public Task<List<Team>> GetAllAsync()
        {
            return _context.Teams
                .AsNoTracking()
                .ToListAsync();
        }

        public void Insert(Team team)
        {

            _context.Entry(team).State = EntityState.Added;
        }

        public void Update(Team team)
        {
            _context.Entry(team).State = EntityState.Modified;
        }

        public void Delete(Team team)
        {
            _context.Entry(team).State = EntityState.Deleted;
        }
    }
}
