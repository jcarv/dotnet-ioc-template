namespace DotNet.IoC.Template.Presentation.ViewModels.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PlayerViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [StringLength(2040, ErrorMessage = "Observations are too long.")]
        public string Observations { get; set; }

        public string CountryId { get; set; }

        public string Country { get; set; }

        public string TeamId { get; set; }

        public string Team { get; set; }
    }
}
