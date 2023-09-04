namespace DotNet.IoC.Template.Presentation.WebAPI.Controllers
{
    using DotNet.IoC.Template.Application.Services.Countries;
    using DotNet.IoC.Template.Presentation.ViewModels.Mappings;
    using DotNet.IoC.Template.Presentation.ViewModels.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Get a Country by Id
        /// </summary>
        /// <param name="id">Country identifier</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CountryViewModel), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CountryViewModel>> Get(int id)
        {
            var country = await _countryService.FindAsync(id).ConfigureAwait(false);

            if (country == null)
                return NotFound();

            return Ok(country.ToViewModel());
        }

        /// <summary>
        /// Get all countries
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CountryViewModel>), 200)]
        public async Task<ActionResult<IEnumerable<CountryViewModel>>> Get()
        {
            var countries = await _countryService.GetAllAsync().ConfigureAwait(false);

            return Ok(countries.ToViewModel().ToList());
        }

        /// <summary>
        /// Create a Country
        /// </summary>
        /// <param name="country">Country</param>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<CountryViewModel>> Post([FromBody] CountryViewModel country)
        {
            try
            {
                if (country == null)
                    return BadRequest();

                if (string.IsNullOrEmpty(country.Name))
                {
                    ModelState.AddModelError("Name", "The name shouldn't be empty");
                }

                if (string.IsNullOrEmpty(country.IsoCode))
                {
                    ModelState.AddModelError("IsoCode", "The ISO code shouldn't be empty");
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newCountry = await _countryService.CreateAsync(country.ToDto());

                return CreatedAtAction(nameof(Get), new { id = newCountry.Id }, newCountry.ToViewModel());
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException.Message.Contains("duplicate key"))
                {
                    ModelState.AddModelError("duplicatekey", ex.InnerException.Message);
                }
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Edit a Country
        /// </summary>
        /// <param name="updatedCountry">New values of the country</param>
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Put([FromBody] CountryViewModel updatedCountry)
        {
            try
            {
                if (updatedCountry == null || !updatedCountry.Id.HasValue)
                    return BadRequest();

                if (string.IsNullOrEmpty(updatedCountry.Name))
                {
                    ModelState.AddModelError("Name", "The name shouldn't be empty");
                }

                if (string.IsNullOrEmpty(updatedCountry.IsoCode))
                {
                    ModelState.AddModelError("IsoCode", "The ISO code shouldn't be empty");
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var currentCountry = await _countryService.FindAsync(updatedCountry.Id.Value);

                if (currentCountry == null)
                    return NotFound();

                await _countryService.UpdateAsync(updatedCountry.ToDto());

                return NoContent();
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException.Message.Contains("duplicate key"))
                {
                    ModelState.AddModelError("duplicatekey", ex.InnerException.Message);
                }
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Delete a Country
        /// </summary>
        /// <param name="id">Country identifier</param>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<CountryViewModel>> Delete(int id)
        {
            try
            {
                var country = await _countryService.FindAsync(id);

                if (country == null)
                    return NotFound();

                await _countryService.DeleteAsync(id);

                return NoContent();
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException.Message.Contains("DELETE statement conflicted with the REFERENCE"))
                {
                    ModelState.AddModelError("deleteconflict", ex.InnerException.Message);
                }
                return BadRequest(ModelState);
            }
        }
    }
}