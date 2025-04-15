
namespace Domain.Product.Entities
{
    public class ProductImage
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public string? Url { get; private set; }
        private ProductImage(Guid id, Guid productId, string? url)
        {
            Id = id;
            ProductId = productId;
            Url = url ?? throw new ArgumentNullException(nameof(url));
            if (!Uri.IsWellFormedUriString(Url, UriKind.Absolute))
            {
                throw new ArgumentException("Invalid URL format.", nameof(url));
            }
        }

        public static ProductImage Create(Guid productid, string? url)
        {
            return new ProductImage(Guid.NewGuid(), productid, url);
        }
    }
}