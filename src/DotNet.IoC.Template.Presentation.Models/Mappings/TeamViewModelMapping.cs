namespace DotNet.IoC.Template.Presentation.ViewModels.Mappings
{
    using DotNet.IoC.Template.Application.Dto;
    using DotNet.IoC.Template.Presentation.ViewModels.Models;

    public static class TeamViewModelMapping
    {
        /// <summary>
        /// Convert IEnumerable of TeamViewModel to IEnumerable of TeamDto 
        /// </summary>
        public static IEnumerable<TeamDto> ToDto(this IEnumerable<TeamViewModel> teams)
        {
            return teams?.Select(ToDto);
        }

        /// <summary>
        /// Convert ViewModel to Dto
        /// </summary>
        public static TeamDto ToDto(this TeamViewModel teamViewModel)
        {
            return teamViewModel == null ? null : new TeamDto
            {
                Id = teamViewModel.Id,
                Name = teamViewModel.Name,
                Observations = teamViewModel.Observations,
                CountryId = string.IsNullOrEmpty(teamViewModel.CountryId) ? (int?)null : int.Parse(teamViewModel.CountryId),
                PlayerIds = teamViewModel.PlayerIds,
            };
        }

        /// <summary>
        /// Convert IEnumerable of TeamDto to IEnumerable of TeamViewModel 
        /// </summary>
        public static IEnumerable<TeamViewModel> ToViewModel(this IEnumerable<TeamDto> teams)
        {
            return teams?.Select(ToViewModel);
        }

        /// <summary>
        /// Convert Dto to TeamViewModel
        /// </summary>
        public static TeamViewModel ToViewModel(this TeamDto teamDto)
        {
            return teamDto == null ? null : new TeamViewModel
            {
                Id = teamDto.Id,
                Name = teamDto.Name,
                Observations = teamDto.Observations,
                Country = teamDto.Country == null ? null : teamDto.Country.Name,
                CountryId = teamDto.CountryId.ToString(),
                PlayerIds = teamDto.PlayerIds
            };
        }
    }
}
