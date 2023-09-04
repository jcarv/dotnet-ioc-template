namespace DotNet.IoC.Template.Domain.Core.Repositories
{
    using DotNet.IoC.Template.Domain.Models;

    public interface IPlayersRepository
    {
        Task<Player> FindAsync(int id);

        Task<List<Player>> FindByNameAliasAsync(string name);

        Task<List<Player>> GetAllAsync();

        void Insert(Player player);

        void Update(Player player);

        void Delete(Player player);
    }
}
