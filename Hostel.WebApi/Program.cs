using Hostel.Domain.Context;
using Hostel.Domain.Repositories;
using Hostel.Extensibility.Converters;
using Hostel.Service.Converters;
using Hostel.Service.Services;
using Microsoft.DependencyInjection.Module.Loaders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HostelDbContext>(
    opt =>
        opt.UseNpgsql("Host=localhost;Port=5000;Username=dexter;Password=1410;Database=Hostel;"));
        // opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(
    AssemblyLoader.LoadAssemblies()
                  .Where(x => x.FullName!.StartsWith("Hostel")));
builder.Services.AddTransient(typeof(IModelConverter<,>), typeof(ModelConverter<,>));
builder.Services.AddTransient<IHostelRepository, HostelRepository>();
builder.Services.AddTransient<ITenantRepository, TenantRepository>();
builder.Services.AddTransient<IHostelService, HostelService>();
builder.Services.AddTransient<ITenantService, TenantService>();
var app = builder.Build();

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