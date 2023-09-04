using DotNet.IoC.Template.Application.Dto;
using DotNet.IoC.Template.Domain.Models;

namespace DotNet.IoC.Template.Application.Services.Mappings
{
    public static class CountryMapping
    {
        /// <summary>
        /// Convert IEnumerable of Country to IEnumerable of CountryDto 
        /// </summary>
        public static IEnumerable<CountryDto> ToDto(this IEnumerable<Country> countries)
        {
            return countries?.Select(ToDto);
        }

        /// <summary>
        /// Convert Model to Dto
        /// </summary>
        public static CountryDto ToDto(this Country country)
        {
            return country == null ? null : new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                IsoCode = country.IsoCode,
                Observations = country.Observations
            };
        }

        /// <summary>
        /// Convert IEnumerable of CountryDto to IEnumerable of Country
        /// </summary>
        public static IEnumerable<Country> ToModel(this IEnumerable<CountryDto> countries)
        {
            return countries?.Select(ToModel);
        }

        /// <summary>
        /// Convert Dto to Model
        /// </summary>
        public static Country ToModel(this CountryDto country)
        {
            return country == null ? null : new Country
            {
                Name = country.Name,
                IsoCode = country.IsoCode,
                Observations = country.Observations
            };
        }
    }
}
