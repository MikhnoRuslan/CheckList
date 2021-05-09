using CheckList.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CheckList.DAL
{
    public class CheckListContext : IdentityDbContext<User>
    {
        public CheckListContext(DbContextOptions<CheckListContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Fittings> Fittings { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CheckListOfProduct> CheckListOfProducts { get; set; }
        public DbSet<Packing> Packings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Fittings>().ToTable("Fittings");
            builder.Entity<Task>().ToTable("Tasks");
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<CheckListOfProduct>().ToTable("CheckListOfProduct");
            builder.Entity<Packing>().ToTable("Packing");
        }
    }
}
