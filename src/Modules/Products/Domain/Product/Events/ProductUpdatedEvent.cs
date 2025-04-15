
namespace Domain.Product.Events
{
    public class ProductUpdatedEvent
    {
        public Product Product { get; }
        public ProductUpdatedEvent(Product product)
        {
            Product = product;
        }
    }
}