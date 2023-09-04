namespace DotNet.IoC.Template.Domain.Models
{
    public class TeamsPlayers
    {
        public virtual Team Team { get; set; }

        public int TeamId { get; set; }

        public virtual Player Player { get; set; }

        public int PlayerId { get; set; }

        public DateTime ContractStart { get; set; }

        public DateTime? ContractEnd { get; set; }
    }
}
