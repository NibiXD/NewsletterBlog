namespace Newsletter.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public User(int id, string name, string surname, string email) : base(id)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
