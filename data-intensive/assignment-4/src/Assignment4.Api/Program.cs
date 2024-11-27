using Microsoft.EntityFrameworkCore;
using Assignment4.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HelsinkiDBContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("HelsinkiDBConn") ?? throw new InvalidOperationException("Connectionstring 'HelsinkiDBConn' not found!"));
});

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
