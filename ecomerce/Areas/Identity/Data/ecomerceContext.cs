using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecomerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ecomerce.Data
{
    public class ecomerceContext : IdentityDbContext<IdentityUser>
    {
        public ecomerceContext(DbContextOptions<ecomerceContext> options)
            : base(options)
        {
        }

        protected ecomerceContext(DbContextOptions options)
            : base(options)
        {
        }
        public virtual DbSet<TblCart> TblCart { get; set; }
        public virtual DbSet<TblCartStatus> TblCartStatus { get; set; }
        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblIotUsers> TblIotUsers { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblShippingDetails> TblShippingDetails { get; set; }
        public virtual DbSet<TblSlideImage> TblSlideImage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Tbl_Cart__51BCD7B7F7E8BC66");

                entity.ToTable("Tbl_Cart");

                entity.HasOne(d => d.CartStatus)
                    .WithMany(p => p.TblCart)
                    .HasForeignKey(d => d.CartStatusId)
                    .HasConstraintName("FK_Tbl_Cart_Tbl_CartStatus");

                

               
            });

            modelBuilder.Entity<TblCartStatus>(entity =>
            {
                entity.HasKey(e => e.CartStatusId)
                    .HasName("PK__Tbl_Cart__031908A81BD04AE9");

                entity.ToTable("Tbl_CartStatus");

                entity.Property(e => e.CartStatus)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Tbl_Cate__19093A0B98B84E79");

                entity.ToTable("Tbl_Category");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__Tbl_Cate__8517B2E024832BE2")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblIotUsers>(entity =>
            {
                entity.HasKey(e => e.IotId)
                    .HasName("PK_IOT_users");

                entity.ToTable("Tbl_IotUsers");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                
            });

          


            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Tbl_Prod__B40CC6CD13FC4977");

                entity.ToTable("Tbl_Product");

                entity.HasIndex(e => e.ProductName)
                    .HasName("UQ__Tbl_Prod__DD5A978A4FD147D8")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductImage).IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Tbl_Produ__Categ__398D8EEE");
            });

            modelBuilder.Entity<TblRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Tbl_Role__8AFACE1A68AA8ABB");

                entity.ToTable("Tbl_Roles");

                entity.HasIndex(e => e.RoleName)
                    .HasName("UQ__Tbl_Role__8A2B6160582CE7B7")
                    .IsUnique();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblShippingDetails>(entity =>
            {
                entity.HasKey(e => e.ShippingDetailId)
                    .HasName("PK__Tbl_Ship__FBB36851C3557549");

                entity.ToTable("Tbl_ShippingDetails");

                entity.Property(e => e.Adress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AmountPaid).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.City)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<TblSlideImage>(entity =>
            {
                entity.HasKey(e => e.SlideId)
                    .HasName("PK__Tbl_Slid__9E7CB650351FDDE7");

                entity.ToTable("Tbl_SlideImage");

                entity.Property(e => e.SlideImage).IsUnicode(false);

                entity.Property(e => e.SlideTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            }); 

           base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
           
        }
    }
}
