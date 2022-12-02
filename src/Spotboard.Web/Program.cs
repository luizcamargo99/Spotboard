using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Spotboard.Shared.Data;
using Spotboard.Shared.Interfaces;
using Spotboard.Shared.Repositories;
using Spotboard.Shared.Services;
using Spotboard.Web;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IScreenshotService, ScreenshotService>();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<ISpotifyService, SpotifyService>();
builder.Services.AddScoped<IRepository<AuthorizationResponse>, AuthRepository>();


await builder.Build().RunAsync();
