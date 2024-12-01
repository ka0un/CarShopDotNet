namespace CarShopDotNet.Domain.Entities
{
    public class Owner : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}