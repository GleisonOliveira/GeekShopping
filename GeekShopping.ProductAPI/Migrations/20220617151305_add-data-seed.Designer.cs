﻿// <auto-generated />
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20220617151305_add-data-seed")]
    partial class adddataseed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GeekShopping.ProductAPI.Model.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Roupas"
                        });
                });

            modelBuilder.Entity("GeekShopping.ProductAPI.Model.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("description");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("product");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CategoryId = 1L,
                            Description = "Camiseta",
                            ImageURL = "url",
                            Name = "Camiseta",
                            Price = 5m
                        });
                });

            modelBuilder.Entity("GeekShopping.ProductAPI.Model.Product", b =>
                {
                    b.HasOne("GeekShopping.ProductAPI.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GeekShopping.ProductAPI.Model.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
