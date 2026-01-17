namespace Models.Entities
{
    public class StoreAddress
    {
        public Guid Id { get; set; }

        public required string City { get; set; }

        public required string Street { get; set; }

        public required double Latitude { get; set; }

        public required double Longitude { get; set; }

        public string? PostalCode { get; set; }
    }
}
