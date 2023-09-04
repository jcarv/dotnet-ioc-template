namespace DotNet.IoC.Template.Presentation.WebAPI.Controllers
{
    using DotNet.IoC.Template.Application.Services.Countries;
    using DotNet.IoC.Template.Application.Services.Teams;
    using DotNet.IoC.Template.Presentation.ViewModels.Mappings;
    using DotNet.IoC.Template.Presentation.ViewModels.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly ICountryService _countryService;

        public TeamController(ITeamService teamService, ICountryService countryService)
        {
            _teamService = teamService;
            _countryService = countryService;
        }

        /// <summary>
        /// Get a Team by Id
        /// </summary>
        /// <param name="id">Team identifier</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(TeamViewModel), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TeamViewModel>> Get(int id)
        {
            var team = await _teamService.FindAsync(id).ConfigureAwait(false);

            if (team == null)
                return NotFound();

            return Ok(team.ToViewModel());
        }

        /// <summary>
        /// Get all teams
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TeamViewModel>), 200)]
        public async Task<ActionResult<IEnumerable<TeamViewModel>>> Get()
        {
            var teams = await _teamService.GetAllAsync().ConfigureAwait(false);

            return Ok(teams.ToViewModel().ToList());
        }

        /// <summary>
        /// Create a Team
        /// </summary>
        /// <param name="team">Team</param>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<TeamViewModel>> Post([FromBody] TeamViewModel team)
        {
            try
            {
                if (team == null)
                    return BadRequest();

                if (string.IsNullOrEmpty(team.Name))
                {
                    ModelState.AddModelError("Name", "The name shouldn't be empty");
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newTeam = await _teamService.CreateAsync(team.ToDto());

                return CreatedAtAction(nameof(Get), new { id = newTeam.Id }, newTeam.ToViewModel());
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
        /// Edit a Team
        /// </summary>
        /// <param name="updatedTeam">New values of the team</param>
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Put([FromBody] TeamViewModel updatedTeam)
        {
            try
            {
                if (updatedTeam == null || !updatedTeam.Id.HasValue)
                    return BadRequest();

                if (string.IsNullOrEmpty(updatedTeam.Name))
                {
                    ModelState.AddModelError("Name", "The name shouldn't be empty");
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var currentTeam = await _teamService.FindAsync(updatedTeam.Id.Value);

                if (currentTeam == null)
                    return NotFound();

                await _teamService.UpdateAsync(updatedTeam.ToDto());

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
        /// Delete a Team
        /// </summary>
        /// <param name="id">Team identifier</param>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<TeamViewModel>> Delete(int id)
        {
            try
            {
                var team = await _teamService.FindAsync(id);

                if (team == null)
                    return NotFound();

                await _teamService.DeleteAsync(id);

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

        private async Task UpdateModelState(TeamViewModel team)
        {
            if (string.IsNullOrEmpty(team.Name))
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!string.IsNullOrEmpty(team.CountryId))
            {
                if (Int32.TryParse(team.CountryId, out int j))
                {
                    var country = await _countryService.FindAsync(j);
                    if (country == null)
                    {
                        ModelState.AddModelError("CountryId", "Country does not exist");
                    }
                }
                else
                {
                    ModelState.AddModelError("CountryId", "CountryId could not be parsed");
                }
            }
        }
    }
}