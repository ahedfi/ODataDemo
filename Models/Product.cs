namespace ODataDemo.Models
{
    public class Product
    {
        public Product()
        {
            OrderLines = new HashSet<OrderLine>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public ICollection<OrderLine> OrderLines { get; set; } = [];
    }
}
