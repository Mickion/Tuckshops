﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mickion.tuckshops.warehouse.infrastructure.Persistence;

#nullable disable

namespace mickion.tuckshops.warehouse.infrastructure.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    [Migration("20241029162957_InitMigrationsTwo")]
    partial class InitMigrationsTwo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeasurementProduct", b =>
                {
                    b.Property<Guid>("MeasurementsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MeasurementsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("MeasurementProduct");
                });

            modelBuilder.Entity("mickion.tuckshops.warehouse.domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("tblBrands", (string)null);
                });

            modelBuilder.Entity("mickion.tuckshops.warehouse.domain.Entities.Measurement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("DATETIME");

                    b.Property<double>("Size")
                        .HasColumnType("FLOAT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("tblMeasurements", (string)null);
                });

            modelBuilder.Entity("mickion.tuckshops.warehouse.domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("ExpiryDateTime")
                        .HasColumnType("DATETIME");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("UseByDateTime")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("tblProducts", (string)null);
                });

            modelBuilder.Entity("mickion.tuckshops.warehouse.domain.Entities.Quantity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StockOnHand")
                        .HasColumnType("int");

                    b.Property<int>("StockOnOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("tblQuantities", (string)null);
                });

            modelBuilder.Entity("MeasurementProduct", b =>
                {
                    b.HasOne("mickion.tuckshops.warehouse.domain.Entities.Measurement", null)
                        .WithMany()
                        .HasForeignKey("MeasurementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mickion.tuckshops.warehouse.domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mickion.tuckshops.warehouse.domain.Entities.Product", b =>
                {
                    b.HasOne("mickion.tuckshops.warehouse.domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Brand_Product");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("mickion.tuckshops.warehouse.domain.Entities.Quantity", b =>
                {
                    b.HasOne("mickion.tuckshops.warehouse.domain.Entities.Product", "Product")
                        .WithOne("Quantity")
                        .HasForeignKey("mickion.tuckshops.warehouse.domain.Entities.Quantity", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Quantity_Product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("mickion.tuckshops.warehouse.domain.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("mickion.tuckshops.warehouse.domain.Entities.Product", b =>
                {
                    b.Navigation("Quantity")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
