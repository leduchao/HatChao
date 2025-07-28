using HatChao.Modules.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HatChao.Modules.User.Infrastructure.Data;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<AppUser> AppUsers { get; set; }

    public DbSet<UserFriend> UserFriends { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserFriend>()
            .HasOne(f => f.User)
            .WithMany(u => u.Friends)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserFriend>()
            .HasOne(f => f.Friend)
            .WithMany(u => u.FriendOf)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
