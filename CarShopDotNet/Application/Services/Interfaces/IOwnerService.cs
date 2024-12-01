using CarShopDotNet.Application.Dtos;

namespace CarShopDotNet.Application.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<OwnerDto> GetOwnerByIdAsync(int id);
        Task<IEnumerable<OwnerDto>> GetAllOwnersAsync();
        Task<OwnerDto> CreateOwnerAsync(CreateOwnerDto ownerDto);
        Task<OwnerDto> UpdateOwnerAsync(int id, CreateOwnerDto ownerDto);
        Task DeleteOwnerAsync(int id);
    }
}
