namespace Entities.Base
{
    public class BaseEntity<T>
    {
        public T ID { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
        public DateTime Updated_Date { get; set; }
        public bool Is_Active { get; set; } = true;
    }
}