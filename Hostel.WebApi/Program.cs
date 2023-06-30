using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.DependencyInjection.Module.Loaders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = false,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});
builder.Services.AddSwaggerGen(
    opt =>
    {
        opt.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Name = "Authorization"
        });

        opt.OperationFilter<SecurityRequirementsOperationFilter>();
    });

ServiceLoader.Load(builder.Services);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();