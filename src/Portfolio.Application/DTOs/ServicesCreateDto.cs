using Microsoft.AspNetCore.Http;

namespace Portfolio.Application.DTOs
{
    public class ServicesCreateDto
    {
        public IFormFile ServiceIcon { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
    }
}
