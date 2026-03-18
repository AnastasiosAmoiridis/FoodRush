namespace Services.DTOs.Response
{
    public class CustomerAddressResponseDto
    {
        public Guid Id { get; set; }

        public required string City { get; set; }

        public required string Street { get; set; }

        public required byte Floor { get; set; }

        public required decimal Latitude { get; set; }

        public required decimal Longitude { get; set; }

        public string? PostalCode { get; set; }

        public string? DoorbellName { get; set; }

        public string? Instructions { get; set; }

        public bool IsDeleted { get; set; }
    }
}
