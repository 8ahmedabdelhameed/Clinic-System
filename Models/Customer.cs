using System.ComponentModel.DataAnnotations;

namespace VIPClinicAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string FileNumber { get; set; }

        public DateTime VisitDate { get; set; }

        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }

        public List<Service> Services { get; set; } = new();
    }
}
