using CarRentalMgt.Client.Services;
using CarRentalMgt.Client.Static;
using CarRentalMgt.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace CarRentalMgt.Client.Pages.Colours
{
    //DRG: Partial means this class is a partial implementation that works toghether with other class...
    public partial class Index : IDisposable //DRG We added IDisposable for the Global Error Handling
    {
        //DRG: The Inject were copied from the razor file @inject transformed into [Inject] the AspNetCore.Components was needed for these.
        [Inject] HttpClient _client { get; set; }
        [Inject] IJSRuntime js { get; set; }
        [Inject] HttpInterceptorService _interceptor { get; set; } //DRG Global Error Handling

        //DRG: The code is being moved also from the razor file into this class.
        private List<Colour>? Colours;

        protected async override Task OnInitializedAsync()
        {
            _interceptor.MonitorEvent(); //DRG Global Error Handling
            //DRG To see the console message in the Browser rightclick inspect, go to the Console tab and you will see...
            //Console.WriteLine("Hitting Code Behind");
            Colours = await _client.GetFromJsonAsync<List<Colour>>($"{Endpoints.ColoursEndpoint}");
        }

        async Task Delete(int colourId)
        {
            var colour = Colours.First(q => q.Id == colourId);
            var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {colour.Name}?");
            if (confirm)
            {
                _interceptor.MonitorEvent(); //DRG Global Error Handling
                await _client.DeleteAsync($"{Endpoints.ColoursEndpoint}/{colourId}");
                await OnInitializedAsync();
            }
        }

        public void Dispose()
        {
            _interceptor.DisposeEvent();
        }
    }
}
