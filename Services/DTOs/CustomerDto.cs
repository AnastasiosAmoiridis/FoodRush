using Models.Entities;

namespace Services.DTOs
{
    public class CustomerDto
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public ICollection<CustomerAddress> Addresses { get; set; } = new List<CustomerAddress>();

        public ICollection<OrderHeader> OrderHeaders { get; set; } = new List<OrderHeader>();
    }
}
