namespace Services.DTOs
{
    public class CustomerAddressDto
    {
        public required string City { get; set; }

        public required string Street { get; set; }

        public required byte Floor { get; set; }

        public required decimal Latitude { get; set; }

        public required decimal Longitude { get; set; }

        public string? PostalCode { get; set; }

        public string? DoorbellName { get; set; }

        public string? Instructions { get; set; }     
    }
}
