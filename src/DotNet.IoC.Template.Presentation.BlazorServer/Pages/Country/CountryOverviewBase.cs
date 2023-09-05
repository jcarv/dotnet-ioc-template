namespace DotNet.IoC.Template.Presentation.BlazorServer.Pages.Country
{
    using Blazored.Modal.Services;
    using DotNet.IoC.Template.Presentation.BlazorServer.Components.Country;
    using Microsoft.AspNetCore.Components;

    public class CountryOverviewBase : ComponentBase
    {
        public CountryListBase CountryListComponent { get; set; }

        [CascadingParameter] public IModalService Modal { get; set; } = default!;

        public async void AddCountry()
        {
            var countryDialog = Modal.Show<CountryDialog>("Country");
            var result = await countryDialog.Result;

            if (result.Confirmed)
            {
                CountryListComponent.LoadEntities();
            }
        }
    }
}
