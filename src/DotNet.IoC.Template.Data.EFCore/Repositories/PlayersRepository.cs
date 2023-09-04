namespace DotNet.IoC.Template.Data.EFCore.Repositories
{
    using DotNet.IoC.Template.Domain.Core.Repositories;
    using DotNet.IoC.Template.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    internal class PlayersRepository : IPlayersRepository
    {
        private AppDbContext _context;

        public PlayersRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Player> FindAsync(int id)
        {
            return _context.Players
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Player>> FindByNameAliasAsync(string name)
        {
            return _context.Players
                .AsNoTracking()
                .Where(x => x.NameAlias == name)
                .ToListAsync();
        }

        public Task<List<Player>> GetAllAsync()
        {
            return _context.Players
                .AsNoTracking()
                .ToListAsync();
        }

        public void Insert(Player player)
        {
            _context.Entry(player).State = EntityState.Added;
        }

        public void Update(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
        }

        public void Delete(Player player)
        {
            _context.Entry(player).State = EntityState.Deleted;
        }
    }
}
