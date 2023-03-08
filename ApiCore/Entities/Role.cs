using Entities.Base;

namespace Entities
{
    public class Role : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}