using AppointmentPlanner.Client;
using AppointmentPlanner.Components;
using AppointmentPlanner.Data;
using AppointmentPlanner.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddScoped<UserSessionService>();
builder.Services.AddSingleton<AppointmentService, AppointmentService>();
//builder.Services.AddSingleton<Appointment, Appointment>();
builder.Services.AddSingleton<AppointmentPlanner.Services.AzureEmailService>();
builder.Services.AddControllers();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXpceXRXRmldVUxxWURWYUA=");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// --- SEED DATABASE WITH DEFAULT USER (Development Only) ---
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate(); // Applies any pending migrations
        AppointmentPlanner.Data.DbInitializer.SeedUsers(db); // Seeds the default user if needed
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Routes).Assembly);

app.Run();