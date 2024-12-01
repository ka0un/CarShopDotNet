using CarShopDotNet.Domain.Enums;

namespace CarShopDotNet.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string VIN { get; set; }
        public CarStatus Status { get; set; }
        public int? OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}