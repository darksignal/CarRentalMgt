using CarRentalMgt.Client.Static;
using CarRentalMgt.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalMgt.Client.Services;
using System.Net.Http.Json;

namespace CarRentalMgt.Client.Pages.Vehicles
{
    public partial class Index
    {
        //DRG: The Inject were copied from the razor file @inject transformed into [Inject] the AspNetCore.Components was needed for these.
        [Inject] HttpClient _client { get; set; }
        [Inject] IJSRuntime js { get; set; }
        [Inject] HttpInterceptorService _interceptor { get; set; } //DRG Global Error Handling

        private List<Vehicle> Vehicles;
        protected async override Task OnInitializedAsync()
        {
            _interceptor.MonitorEvent(); //DRG Global Error Handling
            Vehicles = await _client.GetFromJsonAsync<List<Vehicle>>($"{Endpoints.VehiclesEndpoint}");
        }

        async Task Delete(int vehicleId)
        {
            var vehicle = Vehicles.First(q => q.Id == vehicleId);
            var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {vehicle.Vin}?");
            if (confirm)
            {
                await _client.DeleteAsync($"{Endpoints.VehiclesEndpoint}/{vehicleId}");
                await OnInitializedAsync();
            }
        }

        public void Dispose()
        {
            _interceptor.DisposeEvent();
        }
    }
}
