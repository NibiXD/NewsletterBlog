using System;

namespace Newsletter.Models
{
    public class News : BaseEntity
    {
        public string NewsTittle { get; set; }
        public string NewsAuthor { get; set; }
        public string NewsContent { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.UtcNow;

    }
}
