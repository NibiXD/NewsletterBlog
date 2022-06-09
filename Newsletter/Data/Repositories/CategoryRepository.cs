using Newsletter.Models;

namespace Newsletter.Data
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(NewsletterContext context) : base(context)
        {
        }

    }
}
