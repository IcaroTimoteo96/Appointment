using Appointment.Domain.Entidades;

namespace Appointment.Domain.Interfaces
{
    public interface IAppointmentFormRepository
    {
        AppointmentForm SaveAppointmentForm(AppointmentForm appointment);
    }
}
