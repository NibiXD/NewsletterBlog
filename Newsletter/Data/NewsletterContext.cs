using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newsletter.Models;
using System.Collections.Generic;

namespace Newsletter.Data
{
    public class NewsletterContext : IdentityDbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public NewsletterContext(DbContextOptions<NewsletterContext> option) : base(option)
        {
        }

        
    }
}
