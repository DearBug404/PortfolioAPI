

using System.Globalization;
using System.Text.Json.Serialization;

namespace Portfolio.Application.DTOs
{
    public class ReviewViewDto
    {
        public Guid Id { get; set; }
        public string ClientReview { get; set; }
        public string ClientImage { get; set; }
        public string ClientName { get; set; }
        public string ClientProfession { get; set; }
        public string? CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string UpdatedAt { get; set; }
    }
}
