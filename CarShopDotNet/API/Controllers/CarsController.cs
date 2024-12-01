using CarShopDotNet.Application.Dtos;
using CarShopDotNet.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarShopDotNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController(ICarService carService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            var cars = await carService.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            var car = await carService.GetCarByIdAsync(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> CreateCar(CreateCarDto carDto)
        {
            var createdCar = await carService.CreateCarAsync(carDto);
            return CreatedAtAction(nameof(GetCar), new { id = createdCar.Id }, createdCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, CreateCarDto carDto)
        {
            await carService.UpdateCarAsync(id, carDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await carService.DeleteCarAsync(id);
            return NoContent();
        }

        [HttpGet("owner/{ownerId}")]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsByOwner(int ownerId)
        {
            var cars = await carService.GetCarsByOwnerAsync(ownerId);
            return Ok(cars);
        }
    }
}