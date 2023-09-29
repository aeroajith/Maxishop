using Maxishop.Infrastructure;
using Maxishop.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Maxishop.Application;
using Maxishop.Infrastructure.Common;
using Nexusrobotech.shop.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

#region Database Connectivity

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(

    builder.Configuration.GetConnectionString("DefaultConnection")));


#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configuration for Data Seeding

static async void UpdateDatabaseAsync(IHost host)
{
    using var scope = host.Services.CreateScope();
    {
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }
            await SeedData.SeedDataAysnc(context);
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<Logger<Program>>();
            logger.LogError(ex, "An Error occured for migration from seeding Data");
        }
    }
}

#endregion

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

UpdateDatabaseAsync(app);

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
