namespace DotNet.IoC.Template.Application.Dto
{
    public class TeamDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string NameAlias { get; set; }

        public string Observations { get; set; }

        public CountryDto Country { get; set; }

        public int? CountryId { get; set; }

        public ICollection<int> PlayerIds { get; set; }
    }
}
