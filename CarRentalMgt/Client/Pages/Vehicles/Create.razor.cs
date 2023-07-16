using CarRentalMgt.Client.Services;
using CarRentalMgt.Client.Static;
using CarRentalMgt.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace CarRentalMgt.Client.Pages.Vehicles
{
    //DRG: Partial means this class is a partial implementation that works toghether with other class...
    public partial class Create : IDisposable //DRG We added IDisposable for the Global Error Handling
    {
        //DRG: The Inject were copied from the razor file @inject transformed into [Inject] the AspNetCore.Components was needed for these.
        [Inject] HttpClient _client { get; set; }
        [Inject] NavigationManager _navManager { get; set; }
        [Inject] HttpInterceptorService _interceptor { get; set; } //DRG Global Error Handling

        Vehicle vehicle = new Vehicle();

        private async Task CreateVehicle()
        {
            _interceptor.MonitorEvent(); //DRG Global Error Handling
            await _client.PostAsJsonAsync(Endpoints.VehiclesEndpoint, vehicle);
            _navManager.NavigateTo("/vehicles/");
        }
        public void Dispose()
        {
            _interceptor.DisposeEvent();
        }
    }
}