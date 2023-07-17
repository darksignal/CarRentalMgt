using CarRentalMgt.Client;
using CarRentalMgt.Client.Contracts;
using CarRentalMgt.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//DRG: This line is the setup of the HttpClient that will be used in Pages/FetchData.razor as @inject HttpClient Http
//     and is configured to look at the ServerAPI on its address, to look at the API automatically from the razor page.
//builder.Services.AddHttpClient("CarRentalMgt.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
//    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
//DRG For the Global Error Handling we modified the line......
builder.Services.AddHttpClient("CarRentalMgt.ServerAPI", (sp, client) => 
    { 
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
        client.EnableIntercept(sp);
    }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CarRentalMgt.ServerAPI"));

//DRG For Global Error Handling...
builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<HttpInterceptorService>();
//End DRG.....
//DRG For HTTPClient Repository.........
builder.Services.AddTransient(typeof(IHttpRepository<>), typeof(HttpRepository<>));
//End DRG...............................
builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
