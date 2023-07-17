using CarRentalMgt.Client.Contracts;
using CarRentalMgt.Client.Services;
using CarRentalMgt.Client.Static;
using CarRentalMgt.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace CarRentalMgt.Client.Pages.Colours
{
    //DRG: Partial means this class is a partial implementation that works toghether with other class...
    public partial class Index
    {
        //DRG: Changing for the Http Repository to reuse code....
        [Inject] IHttpRepository<Colour>? _client { get; set; }
        [Inject] IJSRuntime js { get; set; }

        //DRG: The code is being moved also from the razor file into this class.
        private IList<Colour>? Colours;

        protected async override Task OnInitializedAsync()
        {
            Colours = await _client.GetAll(Endpoints.ColoursEndpoint);
        }

        async Task Delete(int colourId)
        {
            var colour = Colours.First(q => q.Id == colourId);
            var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {colour.Name}?");
            if (confirm)
            {
                await _client.Delete(Endpoints.ColoursEndpoint,colourId);
                await OnInitializedAsync();
            }
        }
    }
}
