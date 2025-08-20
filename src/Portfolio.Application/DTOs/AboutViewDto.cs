
using System.Globalization;
using System.Text.Json.Serialization;

namespace Portfolio.Application.DTOs
{
    public class AboutViewDto
    {
        public int Id { get; set; }
        public string? AboutImagePath { get; set; }
        public string? Name { get; set; }
        public string? Profession { get; set; }
        public string? Description { get; set; }
        public string? Birthday { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Languages { get; set; }
        public string? FreelanceStatus { get; set; }
        public string? CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string UpdatedAt { get; set; }
    }
}
