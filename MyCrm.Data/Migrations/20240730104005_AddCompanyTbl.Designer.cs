﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCrm.Data.Context;

namespace MyCrm.Data.Migrations
{
    [DbContext(typeof(CrmContext))]
    [Migration("20240730104005_AddCompanyTbl")]
    partial class AddCompanyTbl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.Customer", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Job")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Cursomers");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.Marketer", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Education")
                        .HasColumnType("int");

                    b.Property<string>("FieldStudy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IrCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.ToTable("Marketers");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("IntroduceName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Companies.Company", b =>
                {
                    b.Property<long>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AgentName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Reagent")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Orders.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImageName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinish")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSale")
                        .HasColumnType("bit");

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Orders.OrderSelectedMarketer", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<long>("MarketerId")
                        .HasColumnType("bigint");

                    b.Property<long>("ModifyUserId")
                        .HasColumnType("bigint");

                    b.HasKey("OrderId");

                    b.HasIndex("MarketerId");

                    b.HasIndex("ModifyUserId");

                    b.ToTable("OrderSelectedMarketers");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.Customer", b =>
                {
                    b.HasOne("MyCrm.Domain.Entities.Companies.Company", "Company")
                        .WithMany("Customers")
                        .HasForeignKey("CompanyId");

                    b.HasOne("MyCrm.Domain.Entities.Account.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("MyCrm.Domain.Entities.Account.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.Marketer", b =>
                {
                    b.HasOne("MyCrm.Domain.Entities.Account.User", "User")
                        .WithOne("Marketer")
                        .HasForeignKey("MyCrm.Domain.Entities.Account.Marketer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Orders.Order", b =>
                {
                    b.HasOne("MyCrm.Domain.Entities.Account.Customer", "Customer")
                        .WithMany("OrderCollection")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Orders.OrderSelectedMarketer", b =>
                {
                    b.HasOne("MyCrm.Domain.Entities.Account.Marketer", "Marketer")
                        .WithMany("OrderSelectedMarketers")
                        .HasForeignKey("MarketerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyCrm.Domain.Entities.Account.User", "ModifyUser")
                        .WithMany("OrderSelectedMarketers")
                        .HasForeignKey("ModifyUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyCrm.Domain.Entities.Orders.Order", "Order")
                        .WithOne("OrderSelectedMarketer")
                        .HasForeignKey("MyCrm.Domain.Entities.Orders.OrderSelectedMarketer", "OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Marketer");

                    b.Navigation("ModifyUser");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.Customer", b =>
                {
                    b.Navigation("OrderCollection");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.Marketer", b =>
                {
                    b.Navigation("OrderSelectedMarketers");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.User", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("Marketer");

                    b.Navigation("OrderSelectedMarketers");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Companies.Company", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Orders.Order", b =>
                {
                    b.Navigation("OrderSelectedMarketer");
                });
#pragma warning restore 612, 618
        }
    }
}
