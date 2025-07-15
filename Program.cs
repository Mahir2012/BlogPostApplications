using BlogPostApplication.Models;
using BlogPostSimpleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {


        using var context = new AppDbContext();
        //        if (!context.BlogTypes.Any())
        //        {
        //            var type1 = new BlogType {Status=10, Name="Aaftab", Description="Tech Blog" };
        //            var type2 = new BlogType {Status = 12, Name = "Riyaz", Description = "Food Blogs" };
        //            context.BlogTypes.AddRange(type1,type2);
        //            context.SaveChanges();

        //        }


        //            if (!context.PostTypes.Any())
        //            {
        //                var type1 = new PostType { Status = 10, Name = "Pragun", Description = "Tech Blog" };
        //                var type2 = new PostType { Status = 12, Name = "Tarun", Description = "Tech Blog" };
        //            context.PostTypes.AddRange(type1, type2);
        //            context.SaveChanges();

        //            }

        //        if (!context.Blogs.Any())
        //        {
        //            var type1 = new Blog { Url ="https://Mahir.com", isPublic = true, BlogTypeId =1};
        //            var type2 = new Blog { Url = "https://mahir.com", isPublic = false, BlogTypeId = 2};
        //            context.Blogs.AddRange(type1, type2);
        //            context.SaveChanges();

        //        }

        //        if (!context.Posts.Any())
        //        {
        //            var type1 = new Post {Title="First",  Content="ABC", BlogId=2, PostTypeId=1, UserId=1 };
        //            var type2 = new Post {Title ="Second",Content ="XYZ", BlogId =3, PostTypeId =2, UserId =2};
        //            context.Posts.AddRange(type1, type2);
        //            context.SaveChanges();

        //        }
        //    }
        //}
        //using BlogPostSimpleApp.Models;
        //using Microsoft.EntityFrameworkCore;
        //using System;
        //using System.Linq;
        //class Program
        //{
        //    static void Main()
        //    {


        //        using var context = new AppDbContext();


        //        // Clear existing data
        //        context.Posts.RemoveRange(context.Posts);
        //        context.Blogs.RemoveRange(context.Blogs);
        //        context.BlogTypes.RemoveRange(context.BlogTypes);
        //        context.PostTypes.RemoveRange(context.PostTypes);
        //        context.Users.RemoveRange(context.Users);
        //        context.SaveChanges();

        //        // Reset identity counters
        //        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('BlogType', RESEED, 0)"); // because table name is BlogType
        //        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Blogs', RESEED, 0)");
        //        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Posts', RESEED, 0)");
        //        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('PostType', RESEED, 0)"); // because table name is PostType
        //        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Users', RESEED, 0)");

        //    }
        //}



        //Console.Write("Enter blog URL: ");
        //var url = Console.ReadLine();
        //var blog = new Blog { Url = url };
        //var blogType = context.BlogTypes.FirstOrDefault();
        //if (blogType == null)
        //{
        //    blogType = new BlogType
        //    {
        //        Status = 1,
        //        Name = "General",
        //        Description = "Default blog type"
        //    };
        //    context.BlogTypes.Add(blogType);
        //    context.SaveChanges();
        //}


        //blog.BlogTypeId = blogType.BlogTypeId;
        //context.Blogs.Add(blog);
        //context.SaveChanges();


        //var users = new List<User>
        //{
        //    new User { UserName = "Aaftab", Email = "Aaftab@google.com", PhoneNumber = "7809152930" },
        //    new User { UserName = "Riyaz", Email = "Riyaz@google.com", PhoneNumber = "2345678901" },
        //    new User { UserName = "Mahir", Email = "Mahir@google.com", PhoneNumber = "3456789012" }
        //};

        //context.Users.AddRange(users);
        //context.SaveChanges();


        //    var postType = context.PostTypes.FirstOrDefault();
        //    if (postType == null)
        //    {
        //        postType = new PostType
        //        {
        //            Status = 1,
        //            Name = "General",
        //            Description = "Default post type"
        //        };
        //        context.PostTypes.Add(postType);
        //        context.SaveChanges();
        //    }


        //    var post = new Post
        //    {
        //        Title = "Hello EF Core",
        //        Content = "This is my first post!",
        //        BlogId = blog.BlogId,
        //        PostTypeId = postType.PostTypeId,
        //        UserId = users[0].UserId
        //    };
        //    context.Posts.Add(post);
        //    context.SaveChanges();


        //    var blogs = context.Blogs
        //        .Include(b => b.Posts)
        //        .ThenInclude(p => p.User)
        //        .ToList();

        //    foreach (var b in blogs)
        //    {
        //        Console.WriteLine($"\nBlog: {b.Url}");
        //        foreach (var p in b.Posts)
        //        {
        //            Console.WriteLine($"  Post: {p.Title} - {p.Content} (Author: {p.User?.UserName})");
        //        }
        //    }
        //}
        //}

        //using BlogPostApplication.Models;


        var blogTypes = new List<BlogType>
  {
    new BlogType { Name = "Corporate",Status=1, Description="Corporate Blog"},
    new BlogType { Name = "Personal", Status=2, Description="Personal Blog" },
    new BlogType { Name = "Private", Status=3, Description="Private Blog"},
  };

        var blogs = new List<Blog>
    {
        new Blog { Url = "www.Corporate.com", BlogType = blogTypes[0] },
        new Blog { Url = "www.Personal.com", BlogType = blogTypes[1] },
        new Blog { Url = "www.private.com", BlogType = blogTypes[2] },
    };

        context.BlogTypes.AddRange(blogTypes);
        context.Blogs.AddRange(blogs);
        context.SaveChanges();
    }
}









