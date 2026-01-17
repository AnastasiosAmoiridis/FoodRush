namespace Models.Entities
{
    public class CustomerAddress
    {
        public Guid Id { get; set; }

        public required string City { get; set; }

        public required string Street { get; set; }

        public required byte Floor { get; set; }

        public required double Latitude { get; set; }

        public required double Longitude { get; set; }

        public string? PostalCode { get; set; }

        public string? DoorbellName { get; set; }

        public string? Instructions { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}
