namespace ODataDemo.Models
{
    public class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; } = [];
    }
}
