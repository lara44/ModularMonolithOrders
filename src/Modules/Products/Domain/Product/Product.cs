

using Domain.Common.Models;
using Domain.Product.Entities;
using Domain.Product.Events;
using Domain.Product.ValueObjects;

namespace Domain.Product
{
    public sealed class Product : AggregateRoot
    {
        public string Name { get; private set; }
        public Price Price { get; private set; }
        public int Stock { get; private set; }
        public List<Category.Category> Categories { get; private set; }
        public List<ProductImage> Images { get; private set; }

        private Product(Guid Id, string name, Price price, int stock) : base(Id)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Categories = new List<Category.Category>();
            Images = new List<ProductImage>();
        }
        public static Product Create(string name, Price price, int stock)
        {
            var product = new Product(Guid.NewGuid(), name, price, stock);
            product.AddDomainEvent(new ProductCreatedEvent(product.Id, product.Name, product.Price.Amount, product.Stock));
            return product;
        }

        public void Update(string name, Price price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
            AddDomainEvent(new ProductUpdatedEvent(this));
        }

        public void AddCategory(Category.Category category)
        {
            if (Categories.Any(c => c.Id == category.Id))
                throw new InvalidOperationException("Category already assigned to the product.");

            Categories.Add(category);
        }

        public void RemoveCategory(Guid categoryId)
        {
            var category = Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
                throw new InvalidOperationException("Category not found.");

            Categories.Remove(category);
        }

        public void AddImage(string url)
        {
            if (Images.Any(i => i.Url == url))
            {
                throw new InvalidOperationException("Image already exists.");
            }
            Images.Add(ProductImage.Create(Id, url));
        }
        public void RemoveImage(string url)
        {
            var image = Images.FirstOrDefault(i => i.Url == url);
            if (image == null)
            {
                throw new InvalidOperationException("Image not found.");
            }
            Images.Remove(image);
        }

        public static Product Restore(
            Guid id, string name, Price price, int stock,
            List<Category.Category> categories,
            List<ProductImage> imagenes)
        {
            var product = new Product(id, name, price, stock);

            foreach (var category in categories)
            {
                product.AddCategory(category);
            }

            foreach (var imagen in imagenes)
            {
                product.AddImage(imagen.Url!);
            }

            return product;
        }
    }
}
