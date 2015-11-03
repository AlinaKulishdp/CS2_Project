using Domain.DAO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Data.EFData
{
    public class ProjectContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Goods> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactInfo> ContactInfoes { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<PersonalInfo> PersonalInfoes { get; set; }
        public DbSet<GoodsRow> GoodsRows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public ProjectContext()
            : base("name=ContosoCEContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectContext, Data.Migrations.Configuration>("ContosoCEContext"));
        }
    }
}
