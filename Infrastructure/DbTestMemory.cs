using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;

namespace Infrastructure
{
    public class DbTestMemory : DbContext
    {
        public DbTestMemory(DbContextOptions<DbTestMemory> options)
        : base(options)
        {
            LoadUsers();
        }
        public DbSet<User> Users { get; set; }

        public async Task LoadUsers()
        {
            if (Users != null && !Users.Any())
            {
                Users.AddRange(new()
                {
                    GuidId = Guid.NewGuid(),
                    Email = "laurent.petitdemange0@gmail.com",
                    Name = "Laurent",
                    Password = "VerySecurePassword",
                }, new User()
                {
                    GuidId = Guid.NewGuid(),
                    Email = "test@realworldone.com",
                    Name = "test",
                    Password = "Hey$",
                });
                await SaveChangesAsync();
            }
        }
        public async Task CreateUser(User user)
        {
            Users.Add(user);
            await SaveChangesAsync();
        }
    }
}