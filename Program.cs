using BlogPostApplication.Models;
using BlogPostSimpleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();

        
        var users = new List<User>
        {
            new User { UserName = "Mahir", Email = "Mahir@gmail.com", PhoneNumber = "368-992-0987" },
            new User { UserName = "Riyaz", Email = "Riyaz@gmail.com", PhoneNumber = "983-223-4567" },
            new User { UserName = "Aaftab", Email = "Aaftab@gmail.com", PhoneNumber = "567-987-9876" }
        };

     
        var userEmails = users.Select(u => u.Email).ToList();
        var existingUsers = context.Users
            .Where(u => userEmails.Contains(u.Email))
            .Select(u => u.Email)
            .ToList();

        var newUsers = users.Where(u => !existingUsers.Contains(u.Email)).ToList();
        context.Users.AddRange(newUsers);
        context.SaveChanges();

       
        Console.Write("Enter blog URL: ");
        var url = Console.ReadLine();

        var blog = new Blog { Url = url };
        context.Blogs.Add(blog);
        context.SaveChanges();

       
        var targetEmails = new[] { "Mahir@gmail.com", "Riyaz@gmail.com", "Aaftab@gmail.com" };
        var selectedUsers = context.Users
            .Where(u => targetEmails.Contains(u.Email))
            .ToList();

     
        var posts = new List<Post>();
        foreach (var user in selectedUsers)
        {
            posts.Add(new Post
            {
                Title = $"Welcome Post by {user.UserName}",
                Content = $"Hi, this is {user.UserName}'s first blog post!",
                BlogId = blog.BlogId,
                UserId = user.UserId,
                PostTypeId = 1
            });
        }

        context.Posts.AddRange(posts);
        context.SaveChanges();

        
        var blogs = context.Blogs
                           .Include(b => b.Posts)
                           .ThenInclude(p => p.User)
                           .ToList();

        foreach (var b in blogs)
        {
            Console.WriteLine($"Blog: {b.Url}");
            foreach (var p in b.Posts)
            {
                Console.WriteLine($"  Post: {p.Title} - {p.Content} (by {p.User?.UserName ?? "Unknown"})");
            }
        }
    }
}
