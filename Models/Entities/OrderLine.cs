namespace Models.Entities
{
    public class OrderLine
    {
        public Guid Id { get; set; }

        public string? Notes { get; set; }

        //public Guid OrderHeaderId { get; set; }

        //public OrderHeader OrderHeader { get; set; } = null!;

        //public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
