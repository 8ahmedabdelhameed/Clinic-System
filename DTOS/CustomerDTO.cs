namespace VIPClinicAPI.DTOs
{
    public class CustomerDTO
    {
        public string FullName { get; set; }
        public string FileNumber { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}
