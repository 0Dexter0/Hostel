using Microsoft.DependencyInjection.Module.Loaders;

var builder = WebApplication.CreateBuilder(args);

ServiceLoader.Load(builder.Services);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();