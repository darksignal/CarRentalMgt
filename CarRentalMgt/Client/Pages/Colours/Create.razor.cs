using CarRentalMgt.Client.Contracts;
using CarRentalMgt.Client.Static;
using CarRentalMgt.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CarRentalMgt.Client.Pages.Colours
{
    public partial class Create
    {
        [Inject] IHttpRepository<Colour>? _client { get; set; }
        [Inject] NavigationManager? _navManager { get; set; }

        Colour colour = new Colour();

        private async Task CreateColour()
        {
            await _client.Create(Endpoints.ColoursEndpoint, colour);
            _navManager.NavigateTo("/colours/");
        }
    }
}
