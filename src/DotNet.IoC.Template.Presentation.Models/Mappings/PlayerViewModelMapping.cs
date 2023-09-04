namespace DotNet.IoC.Template.Presentation.ViewModels.Mappings
{
    using DotNet.IoC.Template.Application.Dto;
    using DotNet.IoC.Template.Presentation.ViewModels.Models;

    public static class PlayerViewModelMapping
    {
        /// <summary>
        /// Convert IEnumerable of PlayerViewModel to IEnumerable of PlayerDto 
        /// </summary>
        public static IEnumerable<PlayerDto> ToDto(this IEnumerable<PlayerViewModel> players)
        {
            return players?.Select(ToDto);
        }

        /// <summary>
        /// Convert ViewModel to Dto
        /// </summary>
        public static PlayerDto ToDto(this PlayerViewModel playerViewModel)
        {
            return playerViewModel == null ? null : new PlayerDto
            {
                Id = playerViewModel.Id,
                Name = playerViewModel.Name,
                Observations = playerViewModel.Observations,
                CountryId = string.IsNullOrEmpty(playerViewModel.CountryId) ? (int?)null : int.Parse(playerViewModel.CountryId),
                TeamId = string.IsNullOrEmpty(playerViewModel.TeamId) ? (int?)null : int.Parse(playerViewModel.TeamId)
            };
        }

        /// <summary>
        /// Convert IEnumerable of PlayerDto to IEnumerable of PlayerViewModel 
        /// </summary>
        public static IEnumerable<PlayerViewModel> ToViewModel(this IEnumerable<PlayerDto> players)
        {
            return players?.Select(ToViewModel);
        }

        /// <summary>
        /// Convert Dto to PlayerViewModel
        /// </summary>
        public static PlayerViewModel ToViewModel(this PlayerDto playerDto)
        {
            return playerDto == null ? null : new PlayerViewModel
            {
                Id = playerDto.Id,
                Name = playerDto.Name,
                Observations = playerDto.Observations,
                Country = playerDto.Country == null ? null : playerDto.Country.Name,
                CountryId = playerDto.CountryId.ToString(),
                Team = playerDto.Team == null ? null : playerDto.Team.Name,
                TeamId = playerDto.TeamId.ToString(),
            };
        }
    }
}
