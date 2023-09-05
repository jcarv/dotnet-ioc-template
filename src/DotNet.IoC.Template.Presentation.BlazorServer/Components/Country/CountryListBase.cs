namespace DotNet.IoC.Template.Presentation.BlazorServer.Components.Country
{
    using Blazored.Modal;
    using Blazored.Modal.Services;
    using Blazored.Toast.Services;
    using DotNet.IoC.Template.Application.Dto;
    using DotNet.IoC.Template.Application.Services.Countries;
    using DotNet.IoC.Template.Presentation.BlazorServer.Components.Confirm;
    using Microsoft.AspNetCore.Components;

    public class CountryListBase : ComponentBase
    {
        [Inject]
        public IToastService ToastService { get; set; }

        [Inject]
        public ICountryService CountryService { get; set; }

        public IEnumerable<CountryDto> Countries { get; set; }

        public bool IsLoading = false;

        [CascadingParameter] public IModalService Modal { get; set; } = default!;

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

        public async void EditCountry(int? id)
        {
            if (id.HasValue)
            {
                var parameters = new ModalParameters();
                parameters.Add(nameof(CountryDialog.Id), id.Value);

                var result = await Modal.Show<CountryDialog>("Country", parameters).Result;

                if (result.Confirmed)
                {
                    Countries = await CountryService.GetAllAsync();
                }

                StateHasChanged();
            }
        }

        public async void DeleteCountry(int? id)
        {
            var result = await Modal.Show<ConfirmDialog>("Delete country").Result;

            if (result.Confirmed && id.HasValue)
            {
                var country = await CountryService.FindAsync(id.Value);

                if (country == null)
                {
                    ToastService.ShowError("Country not found.");
                }
                else
                {
                    await CountryService.DeleteAsync(id.Value);
                    ToastService.ShowSuccess("Country deleted.");

                    await LoadEntities();
                    StateHasChanged();
                }   
            } else
            {
                ToastService.ShowError("Unexpected error.");
            }
        }
    }
}
