using CarRentalMgt.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//DRG: This line is the setup of the HttpClient that will be used in Pages/FetchData.razor as @inject HttpClient Http
//     and is configured to look at the ServerAPI on its address, to look at the API automatically from the razor page.
builder.Services.AddHttpClient("CarRentalMgt.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CarRentalMgt.ServerAPI"));

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
