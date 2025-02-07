using HospitalManagement.Application.Interfaces;
using HospitalManagement.Blazor;
using HospitalManagement.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7293/") });

builder.Services.AddScoped<IPatientService, BlazorPatientService>();


await builder.Build().RunAsync();
