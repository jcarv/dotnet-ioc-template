namespace DotNet.IoC.Template.Presentation.WebAPI.Controllers
{
    using DotNet.IoC.Template.Application.Services.Countries;
    using DotNet.IoC.Template.Application.Services.Players;
    using DotNet.IoC.Template.Application.Services.Teams;
    using DotNet.IoC.Template.Domain.Models;
    using DotNet.IoC.Template.Presentation.ViewModels.Mappings;
    using DotNet.IoC.Template.Presentation.ViewModels.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Numerics;

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ICountryService _countryService;
        private readonly ITeamService _teamService;

        public PlayerController(IPlayerService playerService, ICountryService countryService, ITeamService teamService)
        {
            _playerService = playerService;
            _countryService = countryService;
            _teamService = teamService;
        }

        /// <summary>
        /// Get a Player by Id
        /// </summary>
        /// <param name="id">Player identifier</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PlayerViewModel), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PlayerViewModel>> Get(int id)
        {
            var player = await _playerService.FindAsync(id).ConfigureAwait(false);

            if (player == null)
                return NotFound();

            return Ok(player.ToViewModel());
        }

        /// <summary>
        /// Get all players
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlayerViewModel>), 200)]
        public async Task<ActionResult<IEnumerable<PlayerViewModel>>> Get()
        {
            var players = await _playerService.GetAllAsync().ConfigureAwait(false);

            return Ok(players.ToViewModel().ToList());
        }

        /// <summary>
        /// Create a Player
        /// </summary>
        /// <param name="player">Player</param>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<PlayerViewModel>> Post([FromBody] PlayerViewModel player)
        {
            try
            {
                if (player == null)
                    return BadRequest();

                await UpdateModelState(player);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newPlayer = await _playerService.CreateAsync(player.ToDto());

                return CreatedAtAction(nameof(Get), new { id = newPlayer.Id }, newPlayer.ToViewModel());
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
        /// Edit a Player
        /// </summary>
        /// <param name="updatedPlayer">New values of the player</param>
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Put([FromBody] PlayerViewModel updatedPlayer)
        {
            try
            {
                if (updatedPlayer == null || !updatedPlayer.Id.HasValue)
                    return BadRequest();

                await UpdateModelState(updatedPlayer);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var currentPlayer = await _playerService.FindAsync(updatedPlayer.Id.Value);

                if (currentPlayer == null)
                    return NotFound();

                await _playerService.UpdateAsync(updatedPlayer.ToDto());

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
        /// Delete a Player
        /// </summary>
        /// <param name="id">Player identifier</param>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<PlayerViewModel>> Delete(int id)
        {
            try
            {
                var player = await _playerService.FindAsync(id);

                if (player == null)
                    return NotFound();

                await _playerService.DeleteAsync(id);

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

        private async Task UpdateModelState(PlayerViewModel player)
        {
            if (string.IsNullOrEmpty(player.Name))
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!string.IsNullOrEmpty(player.CountryId))
            {
                if (Int32.TryParse(player.CountryId, out int j))
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

            if (!string.IsNullOrEmpty(player.TeamId))
            {
                if (Int32.TryParse(player.TeamId, out int j))
                {
                    var team = await _teamService.FindAsync(j);
                    if (team == null)
                    {
                        ModelState.AddModelError("TeamId", "Team does not exist");
                    }
                }
                else
                {
                    ModelState.AddModelError("TeamId", "TeamId could not be parsed");
                }
            }
        }
    }
}