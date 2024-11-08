// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using BCD.API.Middlewares;
using BCD.Domain.Entities;
using BCD.Domain.Interfaces.Services;
using BCD.Infrastructure;
using BCD.Service.Business;
using BCD.Service.Category;
using BCD.Service.User;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddDbContext<BCDDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BCDDbContext") ?? throw new InvalidOperationException("Connectionstring 'BCDDbContext' not found!"));
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddHealthChecks();

// Bind CORS settings from appsettings.json
var corsSettings = builder.Configuration.GetSection("CorsSettings").Get<CorsSettings>();

// these two lines to configure Global exception handler and problem detail
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactClientApp",
        policy => policy.WithOrigins(corsSettings.AllowedOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Configure the host to use Serilog for logging
builder.Host.UseSerilog();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

// health check
app.MapHealthChecks("/healthz");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowReactClientApp");

app.Run();

public partial class Program { } // to make it available for intergration test project (https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0)
