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
    [Migration("20240804114019_AddTaskTBL")]
    partial class AddTaskTBL
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

                    b.ToTable("Customers");
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

            modelBuilder.Entity("MyCrm.Domain.Entities.Events.Event", b =>
                {
                    b.Property<long>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreateDate")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Leads.Lead", b =>
                {
                    b.Property<long>("LeadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LeadStatus")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Topic")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LeadId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("OwnerId");

                    b.ToTable("Leads");
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

            modelBuilder.Entity("MyCrm.Domain.Entities.Tasks.CrmTask", b =>
                {
                    b.Property<long>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<long>("MarketerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime>("UntilDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TaskId");

                    b.HasIndex("MarketerId");

                    b.HasIndex("OrderId");

                    b.ToTable("CrmTasks");
                });

            modelBuilder.Entity("MyCrm.Domain.ViewModels.Actions.MarketingAction", b =>
                {
                    b.Property<long>("ActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CrmTaskId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("ActionId");

                    b.HasIndex("CrmTaskId");

                    b.ToTable("MarketingActions");
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

            modelBuilder.Entity("MyCrm.Domain.Entities.Events.Event", b =>
                {
                    b.HasOne("MyCrm.Domain.Entities.Account.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Leads.Lead", b =>
                {
                    b.HasOne("MyCrm.Domain.Entities.Account.User", "CreatedBy")
                        .WithMany("CollectionLeadCreatedBy")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyCrm.Domain.Entities.Account.User", "Owner")
                        .WithMany("CollectionLeadOwner")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Owner");
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

            modelBuilder.Entity("MyCrm.Domain.Entities.Tasks.CrmTask", b =>
                {
                    b.HasOne("MyCrm.Domain.Entities.Account.Marketer", "Marketer")
                        .WithMany("CrmTasks")
                        .HasForeignKey("MarketerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCrm.Domain.Entities.Orders.Order", "Order")
                        .WithMany("CrmTasks")
                        .HasForeignKey("OrderId");

                    b.Navigation("Marketer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MyCrm.Domain.ViewModels.Actions.MarketingAction", b =>
                {
                    b.HasOne("MyCrm.Domain.Entities.Tasks.CrmTask", "CrmTasks")
                        .WithMany("MarketingActions")
                        .HasForeignKey("CrmTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CrmTasks");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.Customer", b =>
                {
                    b.Navigation("OrderCollection");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.Marketer", b =>
                {
                    b.Navigation("CrmTasks");

                    b.Navigation("OrderSelectedMarketers");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Account.User", b =>
                {
                    b.Navigation("CollectionLeadCreatedBy");

                    b.Navigation("CollectionLeadOwner");

                    b.Navigation("Customer");

                    b.Navigation("Events");

                    b.Navigation("Marketer");

                    b.Navigation("OrderSelectedMarketers");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Companies.Company", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Orders.Order", b =>
                {
                    b.Navigation("CrmTasks");

                    b.Navigation("OrderSelectedMarketer");
                });

            modelBuilder.Entity("MyCrm.Domain.Entities.Tasks.CrmTask", b =>
                {
                    b.Navigation("MarketingActions");
                });
#pragma warning restore 612, 618
        }
    }
}
