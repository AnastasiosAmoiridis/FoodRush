using Models.Entities;

namespace Models.Junctions
{
    public class OrderHeaderCode
    {
        public Guid OrderHeaderId { get; set; }

        public OrderHeader OrderHeader { get; set; } = null!;

        public Guid CodeId { get; set; }

        public Code Code { get; set; } = null!;
    }
}
