namespace Appointment.Application.Response
{
    public class AppointmentResponse
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string DoctorId { get; set; }

        public string AppointmentDate { get; set; }

        public AppointmentResponse()
        {
            Id = 0;
            Email = "";
            Phone = "";
            DoctorId = "";
            AppointmentDate = "";
        }
    }
}
