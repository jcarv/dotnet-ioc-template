using DotNet.IoC.Template.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.IoC.Template.Domain.Core
{
    public interface IUnitOfWork
    {
        ICountriesRepository CountriesRepository { get; }

        IPlayersRepository PlayersRepository { get; }

        ITeamsPlayersRepository TeamsPlayersRepository { get; }

        ITeamsRepository TeamsRepository { get; }

        Task SaveChangesAsync();
    }
}
