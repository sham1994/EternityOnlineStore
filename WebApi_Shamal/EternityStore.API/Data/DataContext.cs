using EternityStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EternityStore.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Value> Values { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserPhoto> UserPhotos { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductPhoto> ProductPhotos { get; set; }

        public DbSet<ProductCategory> ProductCategories{ get; set; }

        public DbSet<ProductCategoryPhoto> ProductCategoryPhotos{ get; set; }
    }
}