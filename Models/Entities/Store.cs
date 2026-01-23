namespace Models.Entities
{
    public class Store
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string ImageUrl { get; set; }

        public required string Phone { get; set; }

        public short AvgDeliveryTime { get; set; } = 30; // In minutes. Typical range: 30–120 minutes

        public bool IsOpen { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid BrandId { get; set; }

        public Brand Brand { get; set; } = null!;

        public Guid StoreAddressId { get; set; }

        public StoreAddress StoreAddress { get; set; } = null!;
    }
}
