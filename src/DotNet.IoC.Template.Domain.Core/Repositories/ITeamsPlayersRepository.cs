namespace DotNet.IoC.Template.Domain.Core.Repositories
{
    using DotNet.IoC.Template.Domain.Models;

    public interface ITeamsPlayersRepository
    {
        Task<List<TeamsPlayers>> GetAllByPlayerAsync(int playerId);

        Task<List<TeamsPlayers>> GetAllByTeamAsync(int teamId);

        void Insert(TeamsPlayers teamPlayer);

        void Update(TeamsPlayers teamPlayer);

        void Delete(TeamsPlayers teamPlayer);
    }
}
