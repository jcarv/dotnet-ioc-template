namespace DotNet.IoC.Template.Application.Services.Countries
{
    using DotNet.IoC.Template.Application.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICountryService
    {
        /// <summary>
        /// Find country by Id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        Task<CountryDto> FindAsync(int countryId);

        /// <summary>
        /// Find country by name
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        Task<CountryDto> FindByNameAliasAsync(string countryName);

        /// <summary>
        /// Get all countries
        /// </summary>
        /// <returns></returns>
        Task<List<CountryDto>> GetAllAsync();

        /// <summary>
        /// Create a new country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        Task<CountryDto> CreateAsync(CountryDto country);

        /// <summary>
        /// Update a country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        Task UpdateAsync(CountryDto country);

        /// <summary>
        /// Delete a country
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        Task DeleteAsync(int countryId);
    }
}
