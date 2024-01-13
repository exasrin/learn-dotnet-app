﻿// <auto-generated />
using System;
using DupperFundamental.Entitiy_Framework__EF_.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DupperFundamental.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240108145044_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DupperFundamental.Entitiy_Framework__EF_.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVarchar(250)")
                        .HasColumnName("address");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("customer_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("NVarchar(14)")
                        .HasColumnName("phone_number");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("email");

                    b.HasKey("Id");

                    b.ToTable("m_customer");
                });

            modelBuilder.Entity("DupperFundamental.Entitiy_Framework__EF_.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("product_name");

                    b.Property<long>("ProductPrice")
                        .HasColumnType("bigint")
                        .HasColumnName("product_price");

                    b.Property<int>("stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.HasKey("Id");

                    b.ToTable("m_product");
                });

            modelBuilder.Entity("DupperFundamental.Entitiy_Framework__EF_.Entities.Purchase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("TrancDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("trans_date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("t_purchase");
                });

            modelBuilder.Entity("DupperFundamental.Entitiy_Framework__EF_.Entities.PurchaseDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.Property<Guid>("PurchaseId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("purchase_id");

                    b.Property<int>("Qty")
                        .HasColumnType("int")
                        .HasColumnName("qty");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("t_purchase_detail");
                });

            modelBuilder.Entity("DupperFundamental.Entitiy_Framework__EF_.Entities.Purchase", b =>
                {
                    b.HasOne("DupperFundamental.Entitiy_Framework__EF_.Entities.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("DupperFundamental.Entitiy_Framework__EF_.Entities.PurchaseDetail", b =>
                {
                    b.HasOne("DupperFundamental.Entitiy_Framework__EF_.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DupperFundamental.Entitiy_Framework__EF_.Entities.Purchase", "Purchase")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("DupperFundamental.Entitiy_Framework__EF_.Entities.Purchase", b =>
                {
                    b.Navigation("PurchaseDetails");
                });
#pragma warning restore 612, 618
        }
    }
}