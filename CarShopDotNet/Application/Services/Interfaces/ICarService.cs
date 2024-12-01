using CarShopDotNet.Application.Dtos;

namespace CarShopDotNet.Application.Services.Interfaces
{
    public interface ICarService
    {
        Task<CarDto> GetCarByIdAsync(int id);
        Task<IEnumerable<CarDto>> GetAllCarsAsync();
        Task<CarDto> CreateCarAsync(CreateCarDto carDto);
        Task<CarDto> UpdateCarAsync(int id, CreateCarDto carDto);
        Task DeleteCarAsync(int id);
        Task<IEnumerable<CarDto>> GetCarsByOwnerAsync(int ownerId);
    }
}