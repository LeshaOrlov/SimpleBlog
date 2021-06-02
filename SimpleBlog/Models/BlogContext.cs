using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog.Models
{
    public class BlogContext: DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Article Table
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Author)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.Id);
                
            });
            //User Table
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);                
                entity.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(x => x.Id);
            });
            //Content Table
            modelBuilder.Entity<Content>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Parent)
                    .WithMany(x => x.SubContents)
                    .HasForeignKey(x => x.ParentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

            });
            //Tag Table
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.Articles)
                    .WithMany(x => x.Tags);
                    //.UsingEntity(j => j.ToTable(""))
                    
                    
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=simpleblogdb;Trusted_Connection=True;"));
        }
    }
}
