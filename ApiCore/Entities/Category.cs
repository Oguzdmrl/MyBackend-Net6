using Entities.Base;

namespace Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}