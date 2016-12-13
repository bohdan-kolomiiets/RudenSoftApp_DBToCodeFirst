namespace RudenSoftApp.DAL.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class AppContext : IdentityDbContext<ApplicationUser>
    {
        public AppContext(string connectionString): base(connectionString)
        {
        }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<MainAdmin> MainAdmin { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasRequired(e => e.UserProfile)
                .WithOptional(e => e.Customer)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Customer)
                .WithOptional(e => e.District)
                .HasForeignKey(e => e.DisctrictId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MainAdmin>()
                .HasRequired(e => e.UserProfile)
                .WithOptional(e => e.MainAdmin)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Manager>()
                .HasMany(e => e.Office)
                .WithOptional(e => e.Manager)
                .HasForeignKey(e => e.ManagerId);

            modelBuilder.Entity<Manager>()
                .HasRequired(e => e.UserProfile)
                .WithOptional(e => e.Manager)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItem)
                .WithOptional(e => e.Order)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Seller>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Seller)
                .HasForeignKey(e => e.SellerId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Seller>()
                .HasRequired(e => e.UserProfile)
                .WithOptional(e => e.Seller)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<UserProfile>()
                .HasRequired(e => e.ApplicationUser)
                .WithOptional(e => e.UserProfile)
                .WillCascadeOnDelete(true);
        }
    }
}
