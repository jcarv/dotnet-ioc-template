namespace DotNet.IoC.Template.Application.Services.Mappings
{
    using DotNet.IoC.Template.Application.Dto;
    using DotNet.IoC.Template.Domain.Models;

    public static class PlayerMapping
    {
        /// <summary>
        /// Convert IEnumerable of Player to IEnumerable of PlayerDto 
        /// </summary>
        public static IEnumerable<PlayerDto> ToDto(this IEnumerable<Player> players)
        {
            return players?.Select(ToDto);
        }

        /// <summary>
        /// Convert Model to Dto
        /// </summary>
        public static PlayerDto ToDto(this Player player)
        {
            return player == null ? null : new PlayerDto
            {
                Id = player.Id,
                Name = player.Name,
                Observations = player.Observations,
                CountryId = player.CountryId,
                Country = player.Country.ToDto(),
                TeamId = player.TeamId,
                Team = player.Team.ToDto()
            };
        }

        /// <summary>
        /// Convert IEnumerable of PlayerDto to IEnumerable of Player
        /// </summary>
        public static IEnumerable<Player> ToModel(this IEnumerable<PlayerDto> players)
        {
            return players?.Select(ToModel);
        }

        /// <summary>
        /// Convert Dto to Model
        /// </summary>
        public static Player ToModel(this PlayerDto player)
        {
            return player == null ? null : new Player
            {
                Name = player.Name,
                Observations = player.Observations,
                CountryId = player.CountryId,
                TeamId = player.TeamId
            };
        }
    }
}
