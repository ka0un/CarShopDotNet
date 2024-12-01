namespace CarShopDotNet.Application.Dtos;

public class CreateCarDto
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public string VIN { get; set; }
    public string Status { get; set; }
    public int? OwnerId { get; set; }
}