using Microsoft.EntityFrameworkCore;
using Newsletter.Models;

namespace Newsletter.Data
{
    public class SubscriberRepository : BaseRepository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(NewsletterContext context) : base(context)
        {
        }


    }
}
