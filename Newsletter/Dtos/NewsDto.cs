using System;

namespace Newsletter.Dtos
{
    public class NewsDto
    {
        public string NewsTittle { get; set; }
        public string NewsAuthor { get; set; }
        public string NewsContent { get; set; }
        public int CategoryId { get; set; }
    }
}
