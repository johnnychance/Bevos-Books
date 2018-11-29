using System;
using fa18Team28_FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //You need one db set for each model class
        public DbSet<Book> Books { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountDetail> DiscountDetails { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ManagerOrder> ManagerOrders { get; set; }
        public DbSet<ManagerOrderDetail> ManagerOrderDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<fa18Team28_FinalProject.Models.Supplier> Supplier { get; set; }
    }
}