namespace DotNet.IoC.Template.Presentation.BlazorServer.Components.Confirm
{
    using Blazored.Modal;
    using Microsoft.AspNetCore.Components;

    public class ConfirmDialogBase : ComponentBase
    {
        [CascadingParameter] public BlazoredModalInstance BlazoredModal { get; set; } = default!;

        public async Task Confirm() => await BlazoredModal.CloseAsync();

        public async Task Cancel() => await BlazoredModal.CancelAsync();
    }
}
