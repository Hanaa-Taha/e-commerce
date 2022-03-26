﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ecomerce.Model;

namespace ecomerce.Migrations
{
    [DbContext(typeof(dbSmartAgricultureContext))]
    [Migration("20220325203546_editImageProduct")]
    partial class editImageProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ecomerce.Model.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("fristName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("hasIotSystem")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ecomerce.Model.TblCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartStatusId")
                        .HasColumnType("int");

                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CartId")
                        .HasName("PK__Tbl_Cart__51BCD7B7F7E8BC66");

                    b.HasIndex("CartStatusId");

                    b.HasIndex("MemberId");

                    b.HasIndex("ProductId");

                    b.ToTable("Tbl_Cart");
                });

            modelBuilder.Entity("ecomerce.Model.TblCartStatus", b =>
                {
                    b.Property<int>("CartStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CartStatus")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("CartStatusId")
                        .HasName("PK__Tbl_Cart__031908A81BD04AE9");

                    b.ToTable("Tbl_CartStatus");
                });

            modelBuilder.Entity("ecomerce.Model.TblCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId")
                        .HasName("PK__Tbl_Cate__19093A0B98B84E79");

                    b.HasIndex("CategoryName")
                        .IsUnique()
                        .HasDatabaseName("UQ__Tbl_Cate__8517B2E024832BE2")
                        .HasFilter("[CategoryName] IS NOT NULL");

                    b.ToTable("Tbl_Category");
                });

            modelBuilder.Entity("ecomerce.Model.TblIotUsers", b =>
                {
                    b.Property<int>("IotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IotId")
                        .HasName("PK_IOT_users");

                    b.HasIndex("MemberId");

                    b.ToTable("Tbl_IotUsers");
                });

            modelBuilder.Entity("ecomerce.Model.TblProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Description")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<byte[]>("ProductImage")
                        .IsUnicode(false)
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("VendorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductId")
                        .HasName("PK__Tbl_Prod__B40CC6CD13FC4977");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductName")
                        .IsUnique()
                        .HasDatabaseName("UQ__Tbl_Prod__DD5A978A4FD147D8")
                        .HasFilter("[ProductName] IS NOT NULL");

                    b.HasIndex("VendorId");

                    b.ToTable("Tbl_Product");
                });

            modelBuilder.Entity("ecomerce.Model.TblShippingDetails", b =>
                {
                    b.Property<int>("ShippingDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<decimal?>("AmountPaid")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("City")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentType")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ShippingDetailId")
                        .HasName("PK__Tbl_Ship__FBB36851C3557549");

                    b.HasIndex("MemberId");

                    b.ToTable("Tbl_ShippingDetails");
                });

            modelBuilder.Entity("ecomerce.Model.TblSlideImage", b =>
                {
                    b.Property<int>("SlideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SlideImage")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SlideTitle")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("SlideId")
                        .HasName("PK__Tbl_Slid__9E7CB650351FDDE7");

                    b.ToTable("Tbl_SlideImage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ecomerce.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ecomerce.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ecomerce.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ecomerce.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ecomerce.Model.TblCart", b =>
                {
                    b.HasOne("ecomerce.Model.TblCartStatus", "CartStatus")
                        .WithMany("TblCarts")
                        .HasForeignKey("CartStatusId")
                        .HasConstraintName("FK_Tbl_Cart_Tbl_CartStatus");

                    b.HasOne("ecomerce.Model.AppUser", "Member")
                        .WithMany("TblCarts")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_Tbl_Cart_Tbl_Members");

                    b.HasOne("ecomerce.Model.TblProduct", "Product")
                        .WithMany("TblCarts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Tbl_Cart_Tbl_Product");

                    b.Navigation("CartStatus");

                    b.Navigation("Member");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ecomerce.Model.TblIotUsers", b =>
                {
                    b.HasOne("ecomerce.Model.AppUser", "Member")
                        .WithMany("TblIotUsers")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_IOT_users_Tbl_Members1");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ecomerce.Model.TblProduct", b =>
                {
                    b.HasOne("ecomerce.Model.TblCategory", "Category")
                        .WithMany("TblProducts")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Tbl_Produ__Categ__398D8EEE");

                    b.HasOne("ecomerce.Model.AppUser", "Vendor")
                        .WithMany("TblProducts")
                        .HasForeignKey("VendorId")
                        .HasConstraintName("FK_Tbl_Produ_Tbl_Members");

                    b.Navigation("Category");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("ecomerce.Model.TblShippingDetails", b =>
                {
                    b.HasOne("ecomerce.Model.AppUser", "Member")
                        .WithMany("TblShippingDetails")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK__Tbl_Shipp__Membe__3A81B327");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ecomerce.Model.AppUser", b =>
                {
                    b.Navigation("TblCarts");

                    b.Navigation("TblIotUsers");

                    b.Navigation("TblProducts");

                    b.Navigation("TblShippingDetails");
                });

            modelBuilder.Entity("ecomerce.Model.TblCartStatus", b =>
                {
                    b.Navigation("TblCarts");
                });

            modelBuilder.Entity("ecomerce.Model.TblCategory", b =>
                {
                    b.Navigation("TblProducts");
                });

            modelBuilder.Entity("ecomerce.Model.TblProduct", b =>
                {
                    b.Navigation("TblCarts");
                });
#pragma warning restore 612, 618
        }
    }
}
