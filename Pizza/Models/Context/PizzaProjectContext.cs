using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizza.Models.Context
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

        public virtual DbSet<Busket> Buskets { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<PromoAction> PromoActions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Slider> Sliders { get; set; } = null!;
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
            modelBuilder.Entity<Busket>(entity =>
            {
                entity.ToTable("Busket");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Buskets)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Busket_Product");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.CategoriesName).HasMaxLength(50);

                entity.Property(e => e.ImgPath)
                    .HasMaxLength(300)
                    .HasColumnName("imgPath");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.CategoriesNameNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoriesName)
                    .HasConstraintName("FK_Product_Categories");
            });

            modelBuilder.Entity<PromoAction>(entity =>
            {
                entity.ToTable("PromoAction");

                entity.Property(e => e.Href).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(80);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.NameRole).HasMaxLength(50);
            });

            modelBuilder.Entity<Slider>(entity =>
            {
                entity.ToTable("Slider");

                entity.Property(e => e.Href)
                    .HasMaxLength(150)
                    .HasColumnName("href");

                entity.Property(e => e.ImgPath)
                    .HasMaxLength(150)
                    .HasColumnName("imgPath");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
