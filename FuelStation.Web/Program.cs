using FuelStation.Application;
using FuelStation.Application.Common.Mappings;
using FuelStation.Application.Interfaces;
using FuelStation.Persistence;
using FuelStation.Web.Middleware;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Reflection;

// ������ �������� � ������
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.File("FuelStationWebAppLog-.txt", rollingInterval:
        RollingInterval.Day)
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// ���������� ����������� �������� � ���������

services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IFuelStationDbContext).Assembly));
});

//������� �� ���������� ����� ����������
services.AddApplication();
services.AddPersistence(builder.Configuration);
services.AddControllers();

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "FuelStation API",
        Description = "������ �� ��������� �� ��������� ����",
        Contact = new OpenApiContact
        {
            Name = "Asenchik Oleg",
            Email = string.Empty,
            Url = new Uri("https://github.com/Olgasn/FuelStationSolution")
        }
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// �������� Web ����������
var app = builder.Build();

//������������� ���� ������
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<FuelStationDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        Log.Fatal(exception, "An error occurred while app initialization");
    }
}

// ���������������� ��������� ��������� HTTP �������.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FuelStation API V1");
    });

}

app.UseDefaultFiles();
app.UseStaticFiles();



if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
// ��������������� ������ ��������� ����������
app.UseCustomExceptionHandler();

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();



//app.UseApiVersioning();
app.MapControllers();


app.Run();




