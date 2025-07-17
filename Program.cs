using BlogPostSimpleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        TestDatabase();
    }


    static void GetAllUsers()
    {
        using var context = new AppDbContext();
        var users = context.Users.ToList();

        Console.WriteLine("Current Users ");
        if (!users.Any())
        {
            Console.WriteLine("No users found.");
            return;
        }

        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.UserId}, Name: {user.UserName}, Email: {user.Email}, Phone: {user.PhoneNumber}");
        }
    }


    static void CreateUser(string Name, string Email, string Phone)
    {
        using var context = new AppDbContext();
        var user = new User
        {
            UserName = Name,
            Email = Email,
            PhoneNumber = Phone
        };

        context.Users.Add(user);
        context.SaveChanges();
        Console.WriteLine($"Created user: {Name}");
        
       }


    static void UpdateUser(int userId, string newName)
    {
        using var context = new AppDbContext();
        var user = context.Users.FirstOrDefault(u => u.UserId == userId);

        if (user == null)
        {
            Console.WriteLine($"No user found with ID {userId}");
            return;
        }

        user.UserName = newName;
        context.SaveChanges();
        Console.WriteLine($"Updated user ID {userId} to new name: {newName}");
    }


    static void DeleteUser(int userId)
    {
        using var context = new AppDbContext();
        var user = context.Users.FirstOrDefault(u => u.UserId == userId);

        if (user == null)
        {
            Console.WriteLine($" No user found with ID {userId} to delete.");
            return;
        }

        context.Users.Remove(user);
        context.SaveChanges();
        Console.WriteLine($"Deleted user ID {userId}");
    }


    static void TestDatabase()
    {
        Console.WriteLine("CRUD Tests...");


        using (var context = new AppDbContext())
        {
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Users', RESEED, 0)");


            var users = new List<User>
            {
                new User { UserName = "Riyaz", Email = "Riyaz@gmail.com", PhoneNumber = "9874566324" },
                new User { UserName = "Aaftab", Email = "Aaftab@gmail.com", PhoneNumber = "4576876579" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        GetAllUsers();


        CreateUser("Sohil", "Sohil@gmail.com", "6574345234");
        GetAllUsers();


        UpdateUser(2, "Atik");
        GetAllUsers();


        DeleteUser(1);
        GetAllUsers();
    }
}