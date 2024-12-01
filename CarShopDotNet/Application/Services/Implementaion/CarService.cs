using AutoMapper;
using CarShopDotNet.Application.Dtos;
using CarShopDotNet.Application.Services.Interfaces;
using CarShopDotNet.Domain.Entities;
using CarShopDotNet.Domain.Interfaces;

namespace CarShopDotNet.Application.Services.Implementaion
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IMapper _mapper;
        // mapper is a tool that helps to map objects from one type to another
        // this is same as java's modelMapper
        
        // these variables start with an underscore to indicate that they are private fields

        public CarService(IRepository<Car> carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CarDto> GetCarByIdAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);  //await is used to wait for the result of the asynchronous operation
            return _mapper.Map<CarDto>(car);
        }

        public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarDto>>(cars);
        }

        public async Task<CarDto> CreateCarAsync(CreateCarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await _carRepository.AddAsync(car);
            await _carRepository.SaveChangesAsync();
            return _mapper.Map<CarDto>(car);
        }

        public async Task<CarDto> UpdateCarAsync(int id, CreateCarDto carDto)
        {
            var existingCar = await _carRepository.GetByIdAsync(id);
            if (existingCar == null)
                throw new KeyNotFoundException($"Car with ID {id} not found.");

            _mapper.Map(carDto, existingCar);
            existingCar.UpdatedAt = DateTime.UtcNow;
            _carRepository.Update(existingCar);
            await _carRepository.SaveChangesAsync();

            return _mapper.Map<CarDto>(existingCar);
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
                throw new KeyNotFoundException($"Car with ID {id} not found.");

            _carRepository.Remove(car);
            await _carRepository.SaveChangesAsync();
        }

        // IEnumerable is an interface that represents a collection of objects that can be enumerated
        public async Task<IEnumerable<CarDto>> GetCarsByOwnerAsync(int ownerId)
        {
            var cars = await _carRepository.FindAsync(c => c.OwnerId == ownerId);
            return _mapper.Map<IEnumerable<CarDto>>(cars);
        }
    }
}
