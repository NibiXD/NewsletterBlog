using AutoMapper;
using Newsletter.Dtos;
using Newsletter.Models;

namespace Newsletter.Helpers
{
    public class NewsletterProfile : Profile
    {
        public NewsletterProfile()
        {
            CreateMap<News, NewsDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Subscriber, SubscriberDto>().ReverseMap();
        }
    }
}
