using Hostel.Domain.Context;
using Hostel.Domain.Repositories;
using Hostel.Extensibility.Converters;
using Hostel.Service.Converters;
using Hostel.Service.Services;
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
builder.Services.AddAutoMapper(typeof(HostelDbContext).Assembly);
builder.Services.AddTransient(typeof(IModelConverter<,>), typeof(ModelConverter<,>));
builder.Services.AddTransient<IHostelRepository, HostelRepository>();
builder.Services.AddTransient<IHostelService, HostelService>();

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