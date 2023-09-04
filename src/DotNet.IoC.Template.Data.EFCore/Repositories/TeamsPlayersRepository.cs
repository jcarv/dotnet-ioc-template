namespace DotNet.IoC.Template.Data.EFCore.Repositories
{
    using DotNet.IoC.Template.Domain.Core.Repositories;
    using DotNet.IoC.Template.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class TeamsPlayersRepository : ITeamsPlayersRepository
    {
        private AppDbContext _context;

        public TeamsPlayersRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<TeamsPlayers>> GetAllByTeamAsync(int teamId)
        {
            return _context.TeamsPlayers
                .AsNoTracking()
                .Where(b => b.TeamId == teamId)
                .ToListAsync();
        }

        public Task<List<TeamsPlayers>> GetAllByPlayerAsync(int playerId)
        {
            return _context.TeamsPlayers
                .AsNoTracking()
                .Where(b => b.PlayerId == playerId)
                .ToListAsync();
        }

        public void Insert(TeamsPlayers teamsPlayers)
        {
            _context.Entry(teamsPlayers).State = EntityState.Added;
        }

        public void Update(TeamsPlayers teamsPlayers)
        {
            _context.Entry(teamsPlayers).State = EntityState.Modified;
        }

        public void Delete(TeamsPlayers teamsPlayers)
        {
            _context.Entry(teamsPlayers).State = EntityState.Deleted;
        }
    }
}
