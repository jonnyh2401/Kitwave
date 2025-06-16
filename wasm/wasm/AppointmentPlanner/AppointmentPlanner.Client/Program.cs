using AppointmentPlanner.Data;
using AppointmentPlanner.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AppointmentPlanner.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddScoped<UserSessionService>();
// Register HttpClient for API calls
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AppointmentPlanner.Client.ObservationService>();

builder.Services.AddSingleton<AppointmentService, AppointmentService>();
builder.Services.AddSingleton<Appointment, Appointment>();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXpceXRXRmldVUxxWURWYUA=");
await builder.Build().RunAsync();
