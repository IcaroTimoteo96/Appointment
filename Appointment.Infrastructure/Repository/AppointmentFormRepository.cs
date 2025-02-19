using Appointment.Domain.Entidades;
using Appointment.Domain.Interfaces;

namespace Appointment.Infrastructure.Repository
{
    public class AppointmentFormRepository : IAppointmentFormRepository
    {
        private ApplicationDbContext _context;

        public AppointmentFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public AppointmentForm SaveAppointmentForm(AppointmentForm appointmentForm)
        {
            _context.AppointmentForm.Add(appointmentForm);
            _context.SaveChanges();
            return appointmentForm;
        }
    }
}
