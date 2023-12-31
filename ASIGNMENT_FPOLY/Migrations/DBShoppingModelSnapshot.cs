﻿// <auto-generated />
using System;
using ASIGNMENT_FPOLY.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASIGNMENT_FPOLY.Migrations
{
    [DbContext(typeof(DBShopping))]
    partial class DBShoppingModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Creatdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("shipping_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.BillDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantily")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductId");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Cart", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripttion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.CartDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableQuality")
                        .HasColumnType("int");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte[]>("Image")
                        .HasColumnType("image");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ColorId");

                    b.HasIndex("SizeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.SupplierProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierProducts");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.User", b =>
                {
                    b.Property<Guid>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Stustus")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdUser");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Bill", b =>
                {
                    b.HasOne("ASIGNMENT_FPOLY.Models.User", "User")
                        .WithMany("Bill")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.BillDetail", b =>
                {
                    b.HasOne("ASIGNMENT_FPOLY.Models.Bill", "Bill")
                        .WithMany("BillDetail")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASIGNMENT_FPOLY.Models.Product", "Product")
                        .WithMany("BillDetail")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Cart", b =>
                {
                    b.HasOne("ASIGNMENT_FPOLY.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("ASIGNMENT_FPOLY.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.CartDetail", b =>
                {
                    b.HasOne("ASIGNMENT_FPOLY.Models.Product", "Product")
                        .WithMany("CartDetail")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASIGNMENT_FPOLY.Models.Cart", "Cart")
                        .WithMany("CartDetail")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Product", b =>
                {
                    b.HasOne("ASIGNMENT_FPOLY.Models.Brand", "Brand")
                        .WithMany("Product")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASIGNMENT_FPOLY.Models.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASIGNMENT_FPOLY.Models.Color", "Color")
                        .WithMany("Product")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASIGNMENT_FPOLY.Models.Size", "Size")
                        .WithMany("Product")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Color");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.SupplierProduct", b =>
                {
                    b.HasOne("ASIGNMENT_FPOLY.Models.Product", "Product")
                        .WithMany("SupplierProduct")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASIGNMENT_FPOLY.Models.Supplier", "Supplier")
                        .WithMany("SupplierProduct")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.User", b =>
                {
                    b.HasOne("ASIGNMENT_FPOLY.Models.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Bill", b =>
                {
                    b.Navigation("BillDetail");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Brand", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Cart", b =>
                {
                    b.Navigation("CartDetail");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Color", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Product", b =>
                {
                    b.Navigation("BillDetail");

                    b.Navigation("CartDetail");

                    b.Navigation("SupplierProduct");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Role", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Size", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.Supplier", b =>
                {
                    b.Navigation("SupplierProduct");
                });

            modelBuilder.Entity("ASIGNMENT_FPOLY.Models.User", b =>
                {
                    b.Navigation("Bill");

                    b.Navigation("Cart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
