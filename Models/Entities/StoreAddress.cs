namespace Models.Entities
{
    public class StoreAddress
    {
        public Guid Id { get; set; }

        public required string City { get; set; }

        public required string Street { get; set; }

        public required decimal Latitude { get; set; }

        public required decimal Longitude { get; set; }

        public string? PostalCode { get; set; }

        public Guid StoreId { get; set; }

        public Store Store { get; set; } = null!;
    }
}
