//using BlogPostSimpleApp.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        TestDatabase();
//    }


//    static void GetAllUsers()
//    {
//        using var context = new AppDbContext();
//        var users = context.Users.ToList();

//        Console.WriteLine("Current Users ");
//        if (!users.Any())
//        {
//            Console.WriteLine("No users found.");
//            return;
//        }

//        foreach (var user in users)
//        {
//            Console.WriteLine($"ID: {user.UserId}, Name: {user.UserName}, Email: {user.Email}, Phone: {user.PhoneNumber}");
//        }
//    }


//    static void CreateUser(string Name, string Email, string Phone)
//    {
//        using var context = new AppDbContext();
//        var user = new User
//        {
//            UserName = Name,
//            Email = Email,
//            PhoneNumber = Phone
//        };

//        context.Users.Add(user);
//        context.SaveChanges();
//        Console.WriteLine($"Created user: {Name}");

//       }


//    static void UpdateUser(int userId, string newName)
//    {
//        using var context = new AppDbContext();
//        var user = context.Users.FirstOrDefault(u => u.UserId == userId);

//        if (user == null)
//        {
//            Console.WriteLine($"No user found with ID {userId}");
//            return;
//        }

//        user.UserName = newName;
//       context.SaveChanges();
//        Console.WriteLine($"Updated user ID {userId} to new name: {newName}");
//    }


//    static void DeleteUser(int userId)
//    {
//        using var context = new AppDbContext();
//        var user = context.Users.FirstOrDefault(u => u.UserId == userId);

//        if (user == null)
//        {
//            Console.WriteLine($" No user found with ID {userId} to delete.");
//            return;
//        }

//        context.Users.Remove(user);
//        context.SaveChanges();
//        Console.WriteLine($"Deleted user ID {userId}");
//    }


//    static void TestDatabase()
//    {
//        Console.WriteLine("CRUD Tests...");


//        using (var context = new AppDbContext())
//        {
//            context.Users.RemoveRange(context.Users);
//            context.SaveChanges();
//            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Users', RESEED, 0)");


//            var users = new List<User>
//            {
//                new User { UserName = "Riyaz", Email = "Riyaz@gmail.com", PhoneNumber = "9874566324" },
//                new User { UserName = "Aaftab", Email = "Aaftab@gmail.com", PhoneNumber = "4576876579" }
//            };
//            context.Users.AddRange(users);
//            context.SaveChanges();
//        }

//        GetAllUsers();


//        CreateUser("Sohil", "Sohil@gmail.com", "6574345234");
//        GetAllUsers();


//        UpdateUser(2, "Atik");

//        GetAllUsers();


//        DeleteUser(1);
//        GetAllUsers();
//    }
//}


using BlogPostApplication.Models;
using BlogPostSimpleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Linq;
class Program
{
    static void Main()
    {
        using var context = new AppDbContext();

        //var BlogTypes = new List<BlogType>();


        //var blog1 = new BlogType {Status=1,Name="Mahir",Description="ABCD" };
        //var blog2 = new BlogType { Status = 2, Name = "Riyaz", Description = "XYZS" };
        //context.BlogTypes.AddRange(blog1, blog2);
        //context.SaveChanges();


        // var Statuss = new List<Status>();


        //var blog1 = new Status {StatusCode=1,Name="Mahir",Description="ABCD" };
        //var blog2 = new Status { StatusCode = 2, Name = "Riyaz", Description = "XYZS" };
        // context.Statuses.AddRange(blog1, blog2);
        // context.SaveChanges();

        //var Blogs = new List<Blog>();


        //var blog1 = new Blog{Url="Www.Mahir.com", isPublic=true,BlogTypeId=1,StatusId=1};
        //var blog2 = new Blog{ Url = "Www.Riyaz.com", isPublic = true, BlogTypeId = 2, StatusId = 2 };
        // context.Blogs.AddRange(blog1, blog2);
        // context.SaveChanges();

        //var PostTypess = new List<PostType>();


        //var blog1 = new PostType { Status = 1, Name = "Mahir", Description = "ABCD" };
        //var blog2 = new PostType { Status = 1, Name = "Mahir", Description = "ABCD" };
        //context.PostTypes.AddRange(blog1, blog2);
        //context.SaveChanges();


        //var Users = new List<User>();


        //var blog1 = new User {UserName="Mahir",Email="Mahir20@gmail.com",PhoneNumber="6758465733"  };
        //var blog2 = new User { UserName = "Riyaz", Email = "Riyaz20@gmail.com", PhoneNumber = "567876543" };
        //context.Users.AddRange(blog1, blog2);
        //context.SaveChanges();

        //var Posts = new List<Post>();


        //var blog1 = new Post {Title="Mahir",Content="ABCDE",BlogId=4,PostTypeId=1,UserId=1};
        //var blog2 = new Post { Title = "Riyaz", Content = "CDEDG", BlogId = 5, PostTypeId = 2, UserId = 2};
        //context.Posts.AddRange(blog1, blog2);
        //context.SaveChanges();


        

        var blogsWithType = context.Blogs
            .Include(b => b.BlogType)
            .Select(b => new
            {
                b.BlogId,
                b.Url,
                b.isPublic,
                b.BlogTypeId,
                b.StatusId,
                BlogTypeName = b.BlogType.Name
            })
            .ToList();

        foreach (var blog in blogsWithType)
        {
            Console.WriteLine($"BlogId: {blog.BlogId}, Url: {blog.Url}, isPublic: {blog.isPublic}, BlogType: {blog.BlogTypeName}");
        }

        var blogsWithPostCount = context.Blogs
    .Include(b => b.BlogType)
    .Include(b => b.Posts)
    .Select(b => new
    {
        b.BlogId,
        b.Url,
        b.isPublic,
        b.BlogTypeId,
        b.StatusId,
        BlogTypeName = b.BlogType.Name,
        PostCount = b.Posts.Count
    })
    .ToList();

        foreach (var blog in blogsWithPostCount)
        {
            Console.WriteLine($"BlogId: {blog.BlogId}, Url: {blog.Url}, Type: {blog.BlogTypeName}, Total Posts: {blog.PostCount}");
        }


        var postsWithBlogName = context.Posts
    .Include(p => p.Blog)
    .Select(p => new
    {
        p.PostId,
        p.Content,
       
        BlogUrl = p.Blog.Url
    })
    .ToList();

        foreach (var post in postsWithBlogName)
        {
            Console.WriteLine($"PostId: {post.PostId}, Content: {post.Content},  Blog URL: {post.BlogUrl}");
        }
    }
}
