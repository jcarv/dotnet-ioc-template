namespace DotNet.IoC.Template.Application.Services.Mappings
{
    using DotNet.IoC.Template.Application.Dto;
    using DotNet.IoC.Template.Domain.Models;

    public static class TeamMapping
    {
        /// <summary>
        /// Convert IEnumerable of Team to IEnumerable of TeamDto 
        /// </summary>
        public static IEnumerable<TeamDto> ToDto(this IEnumerable<Team> teams)
        {
            return teams?.Select(ToDto);
        }

        /// <summary>
        /// Convert Model to Dto
        /// </summary>
        public static TeamDto ToDto(this Team team)
        {
            return team == null ? null : new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Observations = team.Observations,
                CountryId = team.CountryId,
                Country = team.Country.ToDto()
            };
        }

        /// <summary>
        /// Convert IEnumerable of TeamDto to IEnumerable of Team
        /// </summary>
        public static IEnumerable<Team> ToModel(this IEnumerable<TeamDto> teams)
        {
            return teams?.Select(ToModel);
        }

        /// <summary>
        /// Convert Dto to Model
        /// </summary>
        public static Team ToModel(this TeamDto team)
        {
            return team == null ? null : new Team
            {
                Name = team.Name,
                Observations = team.Observations,
                CountryId = team.CountryId,
            };
        }
    }
}
