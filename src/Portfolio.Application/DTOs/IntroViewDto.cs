
using System.Globalization;
using System.Text.Json.Serialization;

namespace Portfolio.Application.DTOs
{
    public class IntroViewDto
    {
        public Guid Id { get; set; }
        public string IntroName { get; set; }
        public string ProfessionalTitle { get; set; }
        public string IntroImagePath { get; set; }
        public string ResumePath { get; set; }
        public string? CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string UpdatedAt { get; set; }
    }
}
