namespace Newsletter.Models
{
    public class Subscriber : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

    }
}
