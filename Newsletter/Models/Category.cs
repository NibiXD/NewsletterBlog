using System.Collections.Generic;

namespace Newsletter.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<News> News { get; set; }

        public Category(int id, string name) : base(id)
        {
            Id = id;
            Name = name;
        }
    }
}
