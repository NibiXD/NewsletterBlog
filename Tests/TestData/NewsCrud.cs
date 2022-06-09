using Microsoft.Extensions.DependencyInjection;
using Newsletter.Data;
using Newsletter.Models;
using Xunit;
using Faker;

namespace Tests.TestData
{
    public class NewsCrud : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public NewsCrud(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact]
        [Trait("CRUD", "News")]
        public void News_Create_Test()
        {
            using (var context = _serviceProvider.GetService<NewsletterContext>())
            {
                NewsRepository _repository = new NewsRepository(context);
                News entity = new(
                        Faker.Lorem.Paragraph(1),
                        $"{Faker.Name.First()} {Faker.Name.Middle()}",
                        Faker.Lorem.Paragraph(2),
                        1
                    );

                var newsCreate = _repository.AddNews(entity);
                Assert.NotNull(newsCreate);
                Assert.Equal(entity.NewsTittle, newsCreate.NewsTittle);
                Assert.Equal(entity.NewsAuthor, newsCreate.NewsAuthor);
                Assert.Equal(entity.NewsContent, newsCreate.NewsContent);
            }
        }

        /*public News News_GetAllNews_Test()
        {
            using (var context = _serviceProvider.GetService<NewsletterContext>())
            {
                NewsRepository newsRepository = new NewsRepository(context);

            }
            
        }*/
    }
}
