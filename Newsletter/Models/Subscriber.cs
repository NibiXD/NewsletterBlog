namespace Newsletter.Models
{
    public class Subscriber : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public Subscriber(int id, string name, string surname, string email) : base(id)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
