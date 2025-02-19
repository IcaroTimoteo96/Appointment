using Appointment.Application.UseCases;
using Appointment.Domain.Interfaces;
using Appointment.Infrastructure;
using Appointment.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AppointmentUseCase>();

builder.Services.AddScoped<IAppointmentFormRepository, AppointmentFormRepository>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins(
                "http://127.0.0.1:5173",
                "https://boisterous-salmiakki-4ba650.netlify.app")
              .WithMethods("POST")
              .WithHeaders("Content-Type", "Accept");
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
