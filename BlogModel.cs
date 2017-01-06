using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSqlServer
{
    public class BloggingContext : DbContext
    {
        private static string DBServer = Environment.GetEnvironmentVariable("DBServer");
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server={DBServer};Database=BlogTest;User Id=teammate;Password=teammate;");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

}