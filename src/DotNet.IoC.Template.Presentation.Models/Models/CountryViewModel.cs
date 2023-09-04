namespace DotNet.IoC.Template.Presentation.ViewModels.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CountryViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "ISO code is too long.")]
        public string IsoCode { get; set; }

        [StringLength(2040, ErrorMessage = "Observations are too long.")]
        public string Observations { get; set; }
    }
}
