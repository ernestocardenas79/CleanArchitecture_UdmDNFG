using CleanTeeth.API.Middlewares;
using CleanTeeth.Application;
using CleanTeeth.Persistence;
using CleanTeeth.Infrastructure;
using CleanTeeth.API.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddHostedService<AppointmentReminderJob>();

var app = builder.Build();

app.UseCustomExceptionHandler();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
