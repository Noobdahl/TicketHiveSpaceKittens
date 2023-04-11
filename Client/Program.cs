using Blazored.LocalStorage;
using Blazored.Modal;
using BlazorStrap;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TicketHiveSpaceKittens.Client;
using TicketHiveSpaceKittens.Client.Api;
using TicketHiveSpaceKittens.Client.Services;
using TicketHiveSpaceKittens.Client.Services.Exchange;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient("TicketHiveSpaceKittens.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TicketHiveSpaceKittens.ServerAPI"));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IExchangeService, ExchangeService>();

builder.Services.AddApiAuthorization();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazorStrap();

ApiInitializer.httpClient.BaseAddress = new Uri("https://api.exchangeratesapi.io/v1/latest?access_key=");
ApiInitializer.httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

await builder.Build().RunAsync();