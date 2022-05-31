using Microsoft.EntityFrameworkCore;
using Newsletter.Models;

namespace Newsletter.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(NewsletterContext context) : base(context)
        {
        }


    }
}
