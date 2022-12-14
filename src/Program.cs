using GeoPet.Database.Context;
using GeoPet.Constants;
using GeoPet.Repository;
using GeoPet.Repository.Interfaces;
using GeoPet.Services;
using GeoPet.Services.Interfaces;
using GeoPet.Rest.Interfaces;
using GeoPet.Rest;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews().AddJsonOptions(x =>
{
  x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddHttpClient<IAddressesService, AddressesService>();
builder.Services.AddHttpClient<IPetsService, PetsService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAddressesService, AddressesService>();
builder.Services.AddScoped<IPetsService, PetsService>();
builder.Services.AddScoped<ISittersService, SittersService>();
builder.Services.AddScoped<ILoginService, LoginService>();


builder.Services.AddScoped<IViaCepRest, ViaCepRest>();
builder.Services.AddScoped<INominatinRest, NominatinRest>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<ISitterRepository, SitterRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
  {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  })
  .AddJwtBearer(options =>
  {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
      ValidateIssuer = false,
      ValidateAudience = false,
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret))
    };
  });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
