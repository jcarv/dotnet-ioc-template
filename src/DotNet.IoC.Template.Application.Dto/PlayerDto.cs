namespace DotNet.IoC.Template.Application.Dto
{
    public class PlayerDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string NameAlias { get; set; }

        public string Observations { get; set; }

        public CountryDto Country { get; set; }

        public int? CountryId { get; set; }

        public TeamDto Team { get; set; }

        public int? TeamId { get; set; }
    }
}
