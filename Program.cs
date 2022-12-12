using Microsoft.EntityFrameworkCore;
using GeoPet.Database.Context;
using GeoPet.Repository;
using GeoPet.Repository.Interfaces;
using GeoPet.Services;
using GeoPet.Services.Interfaces;
using GeoPet.Rest.Interfaces;
using GeoPet.Rest;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(x =>
{
  x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddHttpClient<IAddressesService, AddressesService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAddressesService, AddressesService>();
builder.Services.AddScoped<IPetsService, PetsService>();
builder.Services.AddScoped<ISittersService, SittersService>();
builder.Services.AddScoped<IViaCepRest, ViaCepRest>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<ISitterRepository, SitterRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
