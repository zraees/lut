using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using GlobalShopping.Migrations;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EuropeShoppingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EuropeShoppingContext") ?? throw new InvalidOperationException("Connection string 'EuropeShoppingContext' not found.")));

builder.Services.AddDbContext<USAShoppingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("USAShoppingContext") ?? throw new InvalidOperationException("Connection string 'USAShoppingContext' not found.")));

builder.Services.AddDbContext<AsiaShoppingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AsiaShoppingContext") ?? throw new InvalidOperationException("Connection string 'AsiaShoppingContext' not found.")));

builder.Services.AddScoped<IDbcontext, USAShoppingContext>();
builder.Services.AddKeyedScoped<IDbcontext, USAShoppingContext>("USA");
builder.Services.AddKeyedScoped<IDbcontext, EuropeShoppingContext>("EU");
builder.Services.AddKeyedScoped<IDbcontext, AsiaShoppingContext>("AS");

//For storing images/ product photos
var mongoClient = new MongoClient(builder.Configuration.GetConnectionString("MongoDBContext"));

builder.Services.AddDbContext<MongoDBContext>(options =>
    options.UseMongoDB(mongoClient, "mongodb-1"));

builder.Services.AddKeyedScoped<IDbcontext, MongoDBContext>("MDB");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.ApplyMigrations();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Use(async (context, next) =>
{
    // Call the next delegate/middleware in the pipeline.
    await next(context);
});

app.Run();
