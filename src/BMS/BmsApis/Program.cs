using BmsApis.DbEntities;
using BmsApis.Repositories;
using BmsApis.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BmsDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("BmsConnectionString")), ServiceLifetime.Singleton);
builder.Services.AddControllers();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISeatInShowRepository, SeatInShowRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// Add services to the container.
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
app.MapControllers();

app.Run();
