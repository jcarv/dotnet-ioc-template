namespace DotNet.IoC.Template.Application.Services.Countries
{
    using DotNet.IoC.Template.Application.Dto;
    using DotNet.IoC.Template.Application.Services.Mappings;
    using DotNet.IoC.Template.Domain.Core;

    internal class CountryService : ICountryService
    {
        private IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CountryDto> FindAsync(int countryId)
        {
            var country = await _unitOfWork.CountriesRepository.FindAsync(countryId).ConfigureAwait(false);

            return country.ToDto();
        }

        public async Task<CountryDto> FindByNameAliasAsync(string countryName)
        {
            var country = await _unitOfWork.CountriesRepository.FindByNameAliasAsync(Helpers.HelperAlias.ProcessAlias(countryName)).ConfigureAwait(false);

            return country.ToDto();
        }

        public async Task<List<CountryDto>> GetAllAsync()
        {
            var countries = await _unitOfWork.CountriesRepository.GetAllAsync().ConfigureAwait(false);

            return countries.ToDto().ToList();
        }

        public async Task<CountryDto> CreateAsync(CountryDto country)
        {
            var countryModel = country.ToModel();

            countryModel.NameAlias = Helpers.HelperAlias.ProcessAlias(countryModel.Name);
            countryModel.IsoCodeAlias = Helpers.HelperAlias.ProcessAlias(countryModel.IsoCode);

            _unitOfWork.CountriesRepository.Insert(countryModel);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return countryModel.ToDto();
        }

        public async Task UpdateAsync(CountryDto country)
        {
            var currentCountry = await _unitOfWork.CountriesRepository.FindAsync(country.Id.Value).ConfigureAwait(false);

            currentCountry.Name = country.Name;
            currentCountry.NameAlias = Helpers.HelperAlias.ProcessAlias(country.Name);
            currentCountry.IsoCode = country.IsoCode;
            currentCountry.IsoCodeAlias = Helpers.HelperAlias.ProcessAlias(country.IsoCode);
            currentCountry.Observations = country.Observations;

            _unitOfWork.CountriesRepository.Update(currentCountry);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(int countryId)
        {
            var country = await _unitOfWork.CountriesRepository.FindAsync(countryId).ConfigureAwait(false);

            _unitOfWork.CountriesRepository.Delete(country);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}