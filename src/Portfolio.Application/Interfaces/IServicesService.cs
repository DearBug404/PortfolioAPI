
using Portfolio.Application.DTOs;

namespace Portfolio.Application.Interfaces
{
    public interface IServicesService
    {
        Task<ServicesViewDto> AddServicesAsync(ServicesCreateDto dto);
        Task<IEnumerable<ServicesViewDto>> GetAllServicesAsync();
        Task<ServicesViewDto> GetServiceByIdAsync(Guid id);
        Task<ServicesViewDto> UpdateServiceAsync(Guid id, ServicesUpdateDto dto);
        Task DeleteServiceAsync(Guid id);
    }
}
