using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pizza.Context.Entities;

namespace Pizza.Context
{
    public partial class PizzaProjectContext : DbContext
    {
        public PizzaProjectContext()
        {
        }

        public PizzaProjectContext(DbContextOptions<PizzaProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ProductPizzaContext> ProductPizzas { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-M508TRG;Database=PizzaProject;Trusted_Connection=True;TrustServerCertificate=Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProductPizzaContext>(entity =>
            {
                entity.ToTable("ProductPizza");

                entity.Property(e => e.CategoriesName).HasMaxLength(50);

                entity.Property(e => e.ImgPath)
                    .HasMaxLength(300)
                    .HasColumnName("imgPath");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.CategoriesNameNavigation)
                    .WithMany(p => p.ProductPizzas)
                    .HasForeignKey(d => d.CategoriesName)
                    .HasConstraintName("FK_ProductPizza_Categories");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
