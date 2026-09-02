using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.EntityFrameworkCore;
using ServCitasMedicasSOAP.Data;
using ServCitasMedicasSOAP.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CitasMedicasDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CitasMedicasConnection")
    )
);

builder.Services.AddScoped<CitasMedicasService>();

builder.Services
    .AddServiceModelServices()
    .AddServiceModelMetadata();

builder.Services.AddSingleton<IServiceBehavior,
    UseRequestHeadersForMetadataAddressBehavior>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder
        .AddService<CitasMedicasService>()
        .AddServiceEndpoint<CitasMedicasService, ICitasMedicasService>(
            new BasicHttpBinding(),
            "/CitasMedicasService.svc"
        );
});

var metadataBehavior =
    app.Services.GetRequiredService<ServiceMetadataBehavior>();

metadataBehavior.HttpGetEnabled = true;

app.Run();
