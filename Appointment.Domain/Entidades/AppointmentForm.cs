namespace Appointment.Domain.Entidades
{
    public class AppointmentForm
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }
    }
}
