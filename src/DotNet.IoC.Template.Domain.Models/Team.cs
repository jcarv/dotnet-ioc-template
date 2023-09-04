namespace DotNet.IoC.Template.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameAlias { get; set; }

        public string Observations { get; set; }

        public virtual Country? Country { get; set; }

        public int? CountryId { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<TeamsPlayers> TeamsPlayers { get; set; }
    }
}
