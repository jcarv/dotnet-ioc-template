using DotNet.IoC.Template.Application.Dto;
using DotNet.IoC.Template.Application.Services.Mappings;
using DotNet.IoC.Template.Domain.Core;

namespace DotNet.IoC.Template.Application.Services.Players
{
    internal class PlayerService : IPlayerService
    {
        private IUnitOfWork _unitOfWork;

        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PlayerDto> FindAsync(int playerId)
        {
            var player = await _unitOfWork.PlayersRepository.FindAsync(playerId).ConfigureAwait(false);

            return player.ToDto();
        }

        public async Task<List<PlayerDto>> FindByNameAliasAsync(string playerName)
        {
            var players = await _unitOfWork.PlayersRepository.FindByNameAliasAsync(Helpers.HelperAlias.ProcessAlias(playerName)).ConfigureAwait(false);

            return players.ToDto().ToList();
        }

        public async Task<List<PlayerDto>> GetAllAsync()
        {
            var players = await _unitOfWork.PlayersRepository.GetAllAsync().ConfigureAwait(false);

            return players.ToDto().ToList();
        }

        public async Task<PlayerDto> CreateAsync(PlayerDto player)
        {
            var playerModel = player.ToModel();

            playerModel.NameAlias = Helpers.HelperAlias.ProcessAlias(playerModel.Name);

            _unitOfWork.PlayersRepository.Insert(playerModel);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return playerModel.ToDto();
        }

        public async Task UpdateAsync(PlayerDto player)
        {
            var currentPlayer = await _unitOfWork.PlayersRepository.FindAsync(player.Id.Value).ConfigureAwait(false);

            currentPlayer.Name = player.Name;
            currentPlayer.NameAlias = Helpers.HelperAlias.ProcessAlias(player.Name);
            currentPlayer.Observations = player.Observations;

            _unitOfWork.PlayersRepository.Update(currentPlayer);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(int playerId)
        {
            var player = await _unitOfWork.PlayersRepository.FindAsync(playerId).ConfigureAwait(false);

            _unitOfWork.PlayersRepository.Delete(player);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
