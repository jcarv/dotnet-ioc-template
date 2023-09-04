namespace DotNet.IoC.Template.Application.Services.Teams
{
    using DotNet.IoC.Template.Application.Dto;
    using DotNet.IoC.Template.Application.Services.Mappings;
    using DotNet.IoC.Template.Domain.Core;

    internal class TeamService : ITeamService
    {
        private IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TeamDto> FindAsync(int teamId)
        {
            var team = await _unitOfWork.TeamsRepository.FindAsync(teamId).ConfigureAwait(false);

            return team.ToDto();
        }

        public async Task<TeamDto> FindByNameAliasAsync(string teamName)
        {
            var team = await _unitOfWork.TeamsRepository.FindByNameAliasAsync(Helpers.HelperAlias.ProcessAlias(teamName)).ConfigureAwait(false);

            return team.ToDto();
        }

        public async Task<List<TeamDto>> GetAllAsync()
        {
            var teams = await _unitOfWork.TeamsRepository.GetAllAsync().ConfigureAwait(false);

            return teams.ToDto().ToList();
        }

        public async Task<TeamDto> CreateAsync(TeamDto team)
        {
            var teamModel = team.ToModel();

            teamModel.NameAlias = Helpers.HelperAlias.ProcessAlias(teamModel.Name);

            _unitOfWork.TeamsRepository.Insert(teamModel);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return teamModel.ToDto();
        }

        public async Task UpdateAsync(TeamDto team)
        {
            var currentTeam = await _unitOfWork.TeamsRepository.FindAsync(team.Id.Value).ConfigureAwait(false);

            currentTeam.Name = team.Name;
            currentTeam.NameAlias = Helpers.HelperAlias.ProcessAlias(team.Name);
            currentTeam.Observations = team.Observations;

            _unitOfWork.TeamsRepository.Update(currentTeam);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(int teamId)
        {
            var team = await _unitOfWork.TeamsRepository.FindAsync(teamId).ConfigureAwait(false);

            _unitOfWork.TeamsRepository.Delete(team);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
