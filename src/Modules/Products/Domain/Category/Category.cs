
using Domain.Common.Models;

namespace Domain.Category
{
    public class Category : AggregateRoot
    {
        private string? Name { get; init; }
        private Category(Guid Id, string name) : base(Id)
        {
            Name = name;
        }

        public static Category Create(string name)
        {
            var category = new Category(Guid.NewGuid(), name);
            return category;
        }

        public static Category GetCategory(Guid id, string name)
        {
            return new Category(id, name);
        }
    }
}