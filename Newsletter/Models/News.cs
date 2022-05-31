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

        public News(int id, string newsTittle, string newsAuthor, string newsContent, int categoryId) : base(id)
        {
            Id = id;
            NewsTittle = newsTittle;
            NewsAuthor = newsAuthor;
            NewsContent = newsContent;
            CategoryId = categoryId;
        }
    }
}
