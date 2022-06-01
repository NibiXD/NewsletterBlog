using Newsletter.Models;

namespace Newsletter.Data
{
    public class CategoryRepository : BaseRepository<Category>, IBaseRepository<Category>
    {
        public CategoryRepository(NewsletterContext context) : base(context)
        {
        }

    }
}
