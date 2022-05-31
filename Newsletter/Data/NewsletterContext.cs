using Microsoft.EntityFrameworkCore;
using Newsletter.Models;
using System.Collections.Generic;

namespace Newsletter.Data
{
    public class NewsletterContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        public NewsletterContext(DbContextOptions<NewsletterContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<News>().HasData(new List<News>()
            {
                new News(1, "Alguma coisa", "Ricalvo", "Que isso, To careca", 1)
            });
            modelBuilder.Entity<Category>().HasData(new List<Category>()
            {
                new Category(1, "Gaymes")
            });
        }
    }
}
