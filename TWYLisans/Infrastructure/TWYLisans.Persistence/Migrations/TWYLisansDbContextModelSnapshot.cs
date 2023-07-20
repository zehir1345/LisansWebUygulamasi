﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TWYLisans.Persistence.Context;

#nullable disable

namespace TWYLisans.Persistence.Migrations
{
    [DbContext(typeof(TWYLisansDbContext))]
    partial class TWYLisansDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("cityname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ePosta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("mailaddress")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("townId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("townId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Licence", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("endingDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("licencekey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("customerId");

                    b.HasIndex("productId");

                    b.ToTable("Licences");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("productDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("categoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Town", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("cityId")
                        .HasColumnType("int");

                    b.Property<string>("townname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("cityId");

                    b.ToTable("Town");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Customer", b =>
                {
                    b.HasOne("TWYLisans.Domain.Entities.Town", "town")
                        .WithMany("customers")
                        .HasForeignKey("townId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("town");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Licence", b =>
                {
                    b.HasOne("TWYLisans.Domain.Entities.Customer", "customer")
                        .WithMany("licences")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TWYLisans.Domain.Entities.Product", "product")
                        .WithMany("licences")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("product");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Product", b =>
                {
                    b.HasOne("TWYLisans.Domain.Entities.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Town", b =>
                {
                    b.HasOne("TWYLisans.Domain.Entities.City", "city")
                        .WithMany("towns")
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.City", b =>
                {
                    b.Navigation("towns");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Customer", b =>
                {
                    b.Navigation("licences");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Product", b =>
                {
                    b.Navigation("licences");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Town", b =>
                {
                    b.Navigation("customers");
                });
#pragma warning restore 612, 618
        }
    }
}
