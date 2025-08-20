

using System.Globalization;
using System.Text.Json.Serialization;

namespace Portfolio.Application.DTOs
{
    public class ServicesViewDto
    {
        public Guid Id { get; set; }
        public string ServiceIcon { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string? CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string UpdatedAt { get; set; }
    }
}
