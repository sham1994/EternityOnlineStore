using EternityStore.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EternityStore.Data.Repository
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

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<User>(ConfigureUser);
            // modelBuilder.Entity<Order>(ConfigureOrder);
            // modelBuilder.Entity<OrderItem>(ConfigureOrderItem);
            modelBuilder.Entity<OrderHeader>(ConfigureOrderHeader);
            modelBuilder.Entity<OrderDetail>(ConfigureOrderDetail);
        }

     

        public static void ConfigureOrderHeader(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.HasKey(e => e.OrderHeaderId);
            builder.HasMany(e => e.OrderDetails);

        }


        public static void ConfigureOrderDetail(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(e => e.OrderDetailId);
            builder.HasOne(e => e.OrderHeader).WithMany(e => e.OrderDetails).HasForeignKey(e => e.OrderHeaderId);

        }


    }
}