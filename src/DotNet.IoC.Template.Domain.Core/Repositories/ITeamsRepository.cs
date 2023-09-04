namespace DotNet.IoC.Template.Domain.Core.Repositories
{
    using DotNet.IoC.Template.Domain.Models;

    public interface ITeamsRepository
    {
        Task<Team> FindAsync(int id);

        Task<Team> FindByNameAliasAsync(string name);

        Task<List<Team>> GetAllAsync();

        void Insert(Team team);

        void Update(Team team);

        void Delete(Team team);
    }
}
