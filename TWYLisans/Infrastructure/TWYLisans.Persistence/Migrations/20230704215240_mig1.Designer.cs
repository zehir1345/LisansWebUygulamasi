﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TWYLisans.Persistence.Context;

#nullable disable

namespace TWYLisans.Persistence.Migrations
{
    [DbContext(typeof(TWYLisansDbContext))]
    [Migration("20230704215240_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TWYLisans.Domain.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ePosta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("gender")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("town")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Licence", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("expiryDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("licenceKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("productID");

                    b.ToTable("Licences");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("categoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("customerID")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("categoryID");

                    b.HasIndex("customerID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Licence", b =>
                {
                    b.HasOne("TWYLisans.Domain.Entities.Product", "product")
                        .WithMany("licences")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Product", b =>
                {
                    b.HasOne("TWYLisans.Domain.Entities.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TWYLisans.Domain.Entities.Customer", "customer")
                        .WithMany("products")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Customer", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Product", b =>
                {
                    b.Navigation("licences");
                });
#pragma warning restore 612, 618
        }
    }
}
