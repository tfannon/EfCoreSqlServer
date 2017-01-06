using System;
using System.Linq;
using EFCoreSqlServer;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                Console.WriteLine(Environment.GetEnvironmentVariable("DBServer"));
                if (!db.Blogs.Any())
                {
                    Console.WriteLine("Creating some blog entries");
                    for (var i = 0; i < 10; i++)
                    {
                        var semiRandomName = Guid.NewGuid().ToString().Substring(0, 8);
                        var blog = new Blog {Url = $"http://{semiRandomName}.com"};
                        db.Blogs.Add(blog);
                    }
                    db.SaveChanges();
                }
                Console.WriteLine("Reading blog entries");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine($"{blog.BlogId} : {blog.Url}");
                }
                Console.WriteLine("Press return");
                Console.ReadLine();
            }            
        }
    }
}
