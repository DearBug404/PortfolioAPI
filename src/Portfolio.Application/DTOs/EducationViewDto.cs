﻿

using System.Globalization;
using System.Text.Json.Serialization;

namespace Portfolio.Application.DTOs
{
    public class EducationViewDto
    {
        public Guid Id { get; set; }
        public string? Qualification { get; set; }
        public DateOnly? StartDate { get; set; }
        [JsonIgnore]
        public string DisplayStartDate => StartDate?.ToString("yyyy-MM-dd");
        public DateOnly? EndDate { get; set; }
        [JsonIgnore]
        public string DisplayEndDate => IsCurrentlyStudying
            ? "Present"
            : EndDate?.ToString("yyyy-MM-dd") ?? "";
        public bool IsCurrentlyStudying { get; set; }
        public string? InstituteName { get; set; }
        public string? EducationDetail { get; set; }
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        public string? DisplayCreatedAt => CreatedAt?.ToString("yyyy-MM-dd HH:mm tt", CultureInfo.InvariantCulture);
        public string? UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }
        public string? DisplayUpdatedAt => UpdatedAt?.ToString("yyyy-MM-dd HH:mm tt", CultureInfo.InvariantCulture);
    }
}
