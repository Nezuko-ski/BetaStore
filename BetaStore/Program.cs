using BetaStore.Core.Interfaces;
using BetaStore.Core.Services;
using BetaStore.Domain.Entities;
using BetaStore.Infrastructure;
using BetaStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(v =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    v.IncludeXmlComments(xmlPath);
    v.SwaggerDoc("v2", new OpenApiInfo { Title = "BetaStore", Version = "v2" });
});
builder.Services.AddDbContext<BetaStoreDbContext>(options => options.UseSqlServer(config
    .GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<Customer, IdentityRole>().AddEntityFrameworkStores<BetaStoreDbContext>();


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(v => v.SwaggerEndpoint("/swagger/v2/swagger.json", "BetaStore v2"));
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

BetaStoreDbInitializer.SeedUsersAndRolesAsync(app).Wait();

app.Run();
