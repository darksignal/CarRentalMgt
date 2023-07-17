using CarRentalMgt.Client.Contracts;
using CarRentalMgt.Client.Services;
using CarRentalMgt.Client.Static;
using CarRentalMgt.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace CarRentalMgt.Client.Pages.Vehicles
{
    //DRG: Partial means this class is a partial implementation that works toghether with other class...
    public partial class View 
    {
        [Inject] IHttpRepository<Vehicle>? _client { get; set; }
        [Inject] IJSRuntime js { get; set; }
        [Inject] HttpInterceptorService _interceptor { get; set; }

        [Parameter] public int id { get; set; }
        Vehicle vehicle = new Vehicle();

        protected async override Task OnParametersSetAsync()
        {
            vehicle = await _client.GetDetails(Endpoints.VehiclesEndpoint,id);
        }
    }
}
