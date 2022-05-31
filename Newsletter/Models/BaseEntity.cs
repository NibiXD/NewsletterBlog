namespace Newsletter.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public BaseEntity(int id)
        {
            Id = id;
        }
    }
}
