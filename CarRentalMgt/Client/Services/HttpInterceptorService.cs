//DRG: For the Global Error Handling
using Microsoft.AspNetCore.Components;
using System.Net;
using Toolbelt.Blazor;

namespace CarRentalMgt.Client.Services
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor _interceptor;
        private readonly NavigationManager _navManager;

        public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager)
        {
            _interceptor = interceptor;
            _navManager = navManager;
        }

        public void MonitorEvent() => _interceptor.AfterSend += InterceptResponse;

        private void InterceptResponse(object? sender, HttpClientInterceptorEventArgs e)
        {
            string message = string.Empty;
            if (!e.Response.IsSuccessStatusCode)
            {
                var responseCode = e.Response.StatusCode;

                switch (responseCode) 
                {
                    case HttpStatusCode.NotFound:
                        _navManager.NavigateTo("/404");
                        message = "The requested resorce was not found.";
                        break;
                    case HttpStatusCode.Unauthorized:
                    case HttpStatusCode.Forbidden:
                        _navManager.NavigateTo("/unauthorized");
                        message = "You are not authorized to access this resource. ";
                        break;
                    default:
                        _navManager.NavigateTo("/500");
                        message = "Something went wrong, please contact Administrator";
                        break;
                }
                //DRG we want this to stop the execution and see the error, otherwise will continue the execution and for example when an error during creation, will go back to Index page...
                throw new HttpRequestException(message);
            }
        }

        public void DisposeEvent() => _interceptor.AfterSend -= InterceptResponse;
    }
}
