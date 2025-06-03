using LangCommerce.API.Extensions;
using LangCommerce.API.Middlewares;
using LangCommerce.Application.Extensions;
using LangCommerce.Application.Services.Interfaces.Seeders;
using LangCommerce.Infrastucture.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureServices(builder.Configuration);
builder.Services.ConfigureAppServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;

    try
    {
        var seederManager = provider.GetRequiredService<ISeederManager>();
        await seederManager.SeedAll();
        Console.WriteLine("✅ Database seeding completed.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Seeding or job scheduling failed: {ex.Message}");
        throw;
    }
}

app.UseMiddleware<UserContextMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
