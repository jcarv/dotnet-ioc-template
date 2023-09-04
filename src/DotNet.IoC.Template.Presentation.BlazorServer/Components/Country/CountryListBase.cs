namespace DotNet.IoC.Template.Presentation.BlazorServer.Components.Country
{
    using DotNet.IoC.Template.Application.Dto;
    using DotNet.IoC.Template.Application.Services.Countries;
    using Microsoft.AspNetCore.Components;

    public class CountryListBase : ComponentBase
    {
        [Inject]
        public ICountryService CountryService { get; set; }

        public IEnumerable<CountryDto> Countries { get; set; }

        public bool IsLoading = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadEntities();
        }

        public async Task LoadEntities()
        {
            IsLoading = true;

            Countries = await CountryService.GetAllAsync();

            IsLoading = false;

            StateHasChanged();
        }

    }
}
