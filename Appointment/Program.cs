using Appointment.Application.UseCases;
using Appointment.Domain.Interfaces;
using Appointment.Infrastructure;
using Appointment.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AppointmentUseCase>();

builder.Services.AddScoped<IAppointmentFormRepository, AppointmentFormRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5173", "https://boisterous-salmiakki-4ba650.netlify.app") 
               .WithMethods("POST", "GET") 
               .WithHeaders("Content-Type", "Authorization"); 
    });
});


var app = builder.Build();

app.UseCors("MyCorsPolicy");

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
