namespace DotNet.IoC.Template.Application.Services.Players
{
    using DotNet.IoC.Template.Application.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPlayerService
    {
        /// <summary>
        /// Find player by Id
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        Task<PlayerDto> FindAsync(int playerId);

        /// <summary>
        /// Find player by name
        /// </summary>
        /// <param name="PlayerName"></param>
        /// <returns></returns>
        Task<List<PlayerDto>> FindByNameAliasAsync(string playerName);

        /// <summary>
        /// Get all players
        /// </summary>
        /// <returns></returns>
        Task<List<PlayerDto>> GetAllAsync();

        /// <summary>
        /// Create a new player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        Task<PlayerDto> CreateAsync(PlayerDto player);

        /// <summary>
        /// Update a player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        Task UpdateAsync(PlayerDto player);

        /// <summary>
        /// Delete a player
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        Task DeleteAsync(int playerId);
    }
}
