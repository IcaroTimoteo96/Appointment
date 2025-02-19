namespace Appointment.Domain.Entidades
{
    public class AppointmentForm
    {
        public long Id { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required string DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }
      
    }
}
