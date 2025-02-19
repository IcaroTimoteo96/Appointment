using Appointment.Application.BaseResponse;
using Appointment.Application.Request;
using Appointment.Application.Response;
using Appointment.Application.UseCases;
using Appointment.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly AppointmentUseCase _appointmentUseCase;

    public AppointmentController(AppointmentUseCase appointmentUseCase)
    {
        _appointmentUseCase = appointmentUseCase;
    }

    [HttpPost]
    [Route("CreateAppointment")]
    public IActionResult Appointment([FromBody] AppointmentRequest appointmentRequest)
    {
        BaseResponse<AppointmentResponse> response = _appointmentUseCase.CreateAppointmentForm(appointmentRequest);

        return Ok(response);
    }
}
