namespace DotNet.IoC.Template.Presentation.BlazorServer.Components.Country
{
    using Blazored.Modal;
    using Blazored.Toast.Services;
    using DotNet.IoC.Template.Application.Dto;
    using DotNet.IoC.Template.Application.Services.Countries;
    using Microsoft.AspNetCore.Components;

    public class CountryDialogBase : ComponentBase
    {
        [Inject]
        public IToastService ToastService { get; set; }

        [Inject]
        public ICountryService CountryService { get; set; }

        public CountryDto Country { get; set; } = new CountryDto();

        public bool IsLoading = false;

        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;

        [Parameter] public int? Id { get; set; }

        protected override async void OnInitialized()
        {
            await LoadEntities();
        }

        public async Task LoadEntities()
        {
            IsLoading = true;

            if (Id.HasValue)
            {
                Country = await CountryService.FindAsync(Id.Value);
            }
            else
            {
                Country = new CountryDto();
            }

            IsLoading = false;

            StateHasChanged();
        }

        public async Task Cancel()
        {
            Id = null;
            await BlazoredModal.CancelAsync();
        }

        private bool IsCountryValid()
        {
            if (string.IsNullOrEmpty(Country.Name))
            {
                ToastService.ShowError("The name shouldn't be empty");
                return false;
            }

            if (string.IsNullOrEmpty(Country.IsoCode))
            {
                ToastService.ShowError("The ISO code shouldn't be empty");
                return false;
            }

            return true;
        }

        protected async Task Close()
        {
            Id = null;
            await BlazoredModal.CloseAsync();

            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            try
            {
                if (IsCountryValid())
                {
                    if (Id.HasValue)
                    {
                        var currentCountry = await CountryService.FindAsync(Country.Id.Value);

                        if (currentCountry == null)
                        {
                            ToastService.ShowError("Country doesnt exist.");
                        } else
                        {
                            await CountryService.UpdateAsync(Country);
                            ToastService.ShowSuccess("Item updated successfully.");

                            await Close();
                        }
                    }
                    else
                    {
                        await CountryService.CreateAsync(Country);
                        ToastService.ShowSuccess("Item created successfully.");

                        await Close();
                    }
                }
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("duplicate key"))
                {
                    ToastService.ShowError("Operation failed. An item with the same information already exists.");
                }
                else
                {
                    ToastService.ShowError("There was an unexpected error.");
                }
            }
        }
    }
}
