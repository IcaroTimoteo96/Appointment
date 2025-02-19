using Appointment.Application.BaseResponse;
using Appointment.Application.Request;
using Appointment.Application.Response;
using Appointment.Domain.Entidades;
using Appointment.Domain.Interfaces;

namespace Appointment.Application.UseCases
{
    public class AppointmentUseCase
    {
        private readonly IAppointmentFormRepository _appointmentRepository;

        public AppointmentUseCase(IAppointmentFormRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public BaseResponse<AppointmentResponse> CreateAppointmentForm(AppointmentRequest appointmentRequest)
        {
            var baseResponse = new BaseResponse<AppointmentResponse>();

            var appointmentForm = new AppointmentForm()
            {
                Email = appointmentRequest.Email,
                DoctorId = appointmentRequest.DoctorId,
                Phone = appointmentRequest.Phone,
                AppointmentDate = DateTime.Parse(appointmentRequest.AppointmentDate)
            };

            appointmentForm.AppointmentDate = DateTime.SpecifyKind(appointmentForm.AppointmentDate, DateTimeKind.Utc);

            appointmentForm = _appointmentRepository.SaveAppointmentForm(appointmentForm);

            var appointmentResponse = new AppointmentResponse()
            {
                Email = appointmentForm.Email,
                DoctorId = appointmentForm.DoctorId,
                Phone = appointmentForm.Phone,
                AppointmentDate = appointmentForm.AppointmentDate.ToString()
            };

            baseResponse.CreateBaseResponse(true, "Consulta agendada com sucesso! Entraremos em contato em breve.", appointmentResponse);
            
            return baseResponse;
        }
    }
}
