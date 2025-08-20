

using System.Globalization;
using System.Text.Json.Serialization;

namespace Portfolio.Application.DTOs
{
    public class ExperienceViewDto
    {
        public Guid Id { get; set; }
        public string? Designation { get; set; }
        public DateOnly? StartDate { get; set; }
        [JsonIgnore]
        public string DisplayStartDate => StartDate?.ToString("yyyy-MM-dd");
        public DateOnly? EndDate { get; set; }
        [JsonIgnore]
        public string DisplayEndDate => IsCurrentlyWorking
            ? "Present"
            : EndDate?.ToString("yyyy-MM-dd") ?? "";
        public bool IsCurrentlyWorking { get; set; }
        public string? CompanyName { get; set; }
        public string? WorkDetail { get; set; }
        public string? CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string UpdatedAt { get; set; }


    }
}
