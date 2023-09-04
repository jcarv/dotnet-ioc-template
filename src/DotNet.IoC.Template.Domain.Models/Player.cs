namespace DotNet.IoC.Template.Domain.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameAlias { get; set; }

        public string Observations { get; set; }

        public virtual Country? Country { get; set; }

        public int? CountryId { get; set; }

        public virtual Team? Team { get; set; }

        public int? TeamId { get; set; }

        public virtual ICollection<TeamsPlayers> TeamsPlayers { get; set; }
    }
}
