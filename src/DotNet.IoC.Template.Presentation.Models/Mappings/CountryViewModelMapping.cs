namespace DotNet.IoC.Template.Presentation.ViewModels.Mappings
{
    using DotNet.IoC.Template.Application.Dto;
    using DotNet.IoC.Template.Presentation.ViewModels.Models;

    public static class CountryViewModelMapping
    {
        /// <summary>
        /// Convert IEnumerable of CountryViewModel to IEnumerable of CountryDto 
        /// </summary>
        public static IEnumerable<CountryDto> ToDto(this IEnumerable<CountryViewModel> countries)
        {
            return countries?.Select(ToDto);
        }

        /// <summary>
        /// Convert ViewModel to Dto
        /// </summary>
        public static CountryDto ToDto(this CountryViewModel countryViewModel)
        {
            return countryViewModel == null ? null : new CountryDto
            {
                Id = countryViewModel.Id,
                Name = countryViewModel.Name,
                IsoCode = countryViewModel.IsoCode,
                Observations = countryViewModel.Observations
            };
        }

        /// <summary>
        /// Convert IEnumerable of CountryDto to IEnumerable of CountryViewModel 
        /// </summary>
        public static IEnumerable<CountryViewModel> ToViewModel(this IEnumerable<CountryDto> countries)
        {
            return countries?.Select(ToViewModel);
        }

        /// <summary>
        /// Convert Dto to CountryViewModel
        /// </summary>
        public static CountryViewModel ToViewModel(this CountryDto countryDto)
        {
            return countryDto == null ? null : new CountryViewModel
            {
                Id = countryDto.Id,
                Name = countryDto.Name,
                IsoCode = countryDto.IsoCode,
                Observations = countryDto.Observations
            };
        }
    }
}
