namespace DotNet.IoC.Template.Application.Services.Teams
{
    using DotNet.IoC.Template.Application.Dto;

    public interface ITeamService
    {
        /// <summary>
        /// Find team by Id
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<TeamDto> FindAsync(int teamId);

        /// <summary>
        /// Find team by name
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns></returns>
        Task<TeamDto> FindByNameAliasAsync(string teamName);

        /// <summary>
        /// Get all countries
        /// </summary>
        /// <returns></returns>
        Task<List<TeamDto>> GetAllAsync();

        /// <summary>
        /// Create a new team
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        Task<TeamDto> CreateAsync(TeamDto team);

        /// <summary>
        /// Update a team
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        Task UpdateAsync(TeamDto team);

        /// <summary>
        /// Delete a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task DeleteAsync(int teamId);
    }
}
