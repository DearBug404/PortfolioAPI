
using System.Globalization;
using System.Text.Json.Serialization;

namespace Portfolio.Application.DTOs
{
    public class HeaderViewDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string LogoPath { get; set; }
        public string? CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string UpdatedAt { get; set; }

    }
}
