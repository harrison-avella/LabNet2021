using Lab.EF.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab.EF.Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext() : base("name=NorthwindConnection")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Categories> Categories { get; set; }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Territories> Territories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>()
           .HasMany(e => e.Employees1)
           .WithOptional(e => e.Employees2)
           .HasForeignKey(e => e.ReportsTo);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Territories)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("EmployeeTerritories").MapLeftKey("EmployeeID").MapRightKey("TerritoryID"));

            modelBuilder.Entity<Products>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Region>()
                .Property(e => e.RegionDescription)
                .IsFixedLength();

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Territories)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Territories>()
                .Property(e => e.TerritoryDescription)
                .IsFixedLength();




        }
    }
}
