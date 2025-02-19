namespace Appointment.Application.Request
{
    public class AppointmentRequest
    {
        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required string DoctorId { get; set; }

        public required string AppointmentDate { get; set; }

    }
}
