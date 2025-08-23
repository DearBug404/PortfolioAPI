using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.DTOs
{
    public class ServicesUpdateDto
    {
        public IFormFile? ServiceIcon { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
    }
}
