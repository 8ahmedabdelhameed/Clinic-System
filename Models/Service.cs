using System.ComponentModel.DataAnnotations;

namespace VIPClinicAPI.Models
{
    public class Service
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string Department { get; set; }
        public string ServiceName { get; set; }
        public string ProviderName { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public int RatingCommunication { get; set; }
        public int RatingInstructions { get; set; }
        public int RatingResponse { get; set; }
        public int RatingRespect { get; set; }
        public int RatingQuality { get; set; }

        public string Notes { get; set; }
        public string RatingReason { get; set; }
    }
}
