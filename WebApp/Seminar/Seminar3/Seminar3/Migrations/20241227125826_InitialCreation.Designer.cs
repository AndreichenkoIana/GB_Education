﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Seminar3.Data;

#nullable disable

namespace Seminar3.Migrations
{
    [DbContext(typeof(ProductsContext))]
    [Migration("20241227125826_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Seminar3.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<int?>("ProductGroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("product_pkey");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("Seminar3.Models.ProductGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("productgroup_pkey");

                    b.ToTable("productgroups", (string)null);
                });

            modelBuilder.Entity("Seminar3.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("store_pkey");

                    b.HasIndex("ProductId");

                    b.ToTable("stores", (string)null);
                });

            modelBuilder.Entity("Seminar3.Models.Product", b =>
                {
                    b.HasOne("Seminar3.Models.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("ProductGroupId");

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("Seminar3.Models.Store", b =>
                {
                    b.HasOne("Seminar3.Models.Product", "Product")
                        .WithMany("Stores")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Seminar3.Models.Product", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("Seminar3.Models.ProductGroup", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
