namespace DotNet.IoC.Template.Domain.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameAlias { get; set; }

        public string IsoCode { get; set; }

        public string IsoCodeAlias { get; set; }

        public string Observations { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
