namespace DotNet.IoC.Template.Data.EFCore
{
    using DotNet.IoC.Template.Data.EFCore.Repositories;
    using DotNet.IoC.Template.Domain.Core;
    using DotNet.IoC.Template.Domain.Core.Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CountriesRepository = new CountriesRepository(_context);
            PlayersRepository = new PlayersRepository(_context);
            TeamsPlayersRepository = new TeamsPlayersRepository(_context);
            TeamsRepository = new TeamsRepository(_context);
        }

        public ICountriesRepository CountriesRepository { get; set; }

        public IPlayersRepository PlayersRepository { get; set; }

        public ITeamsPlayersRepository TeamsPlayersRepository { get; set; }

        public ITeamsRepository TeamsRepository { get; set; }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
