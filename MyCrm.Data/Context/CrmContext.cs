using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Domain.Entities.Account;
using MyCrm.Domain.Entities.Companies;
using MyCrm.Domain.Entities.Events;
using MyCrm.Domain.Entities.Leads;
using MyCrm.Domain.Entities.Orders;
using MyCrm.Domain.Entities.Tasks;
using MyCrm.Domain.ViewModels.Actions;

namespace MyCrm.Data.Context
{
    public class CrmContext : DbContext
    {
        public CrmContext(DbContextOptions<CrmContext> options) : base(options)
        {

        }

        #region DB Set

        public DbSet<User> Users { get; set; }
        public DbSet<Marketer> Marketers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderSelectedMarketer> OrderSelectedMarketers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<CrmTask> CrmTasks { get; set; }
        public DbSet<MarketingAction> MarketingActions { get; set; }



        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Order Selected Marketer

            modelBuilder.Entity<OrderSelectedMarketer>()
                .HasOne(a => a.Order)
                .WithOne(a => a.OrderSelectedMarketer)
                .HasForeignKey<OrderSelectedMarketer>(a => a.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderSelectedMarketer>()
                .HasOne(a => a.Marketer)
                .WithMany(a => a.OrderSelectedMarketers)
                .HasForeignKey(a => a.MarketerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderSelectedMarketer>()
                .HasOne(a => a.ModifyUser)
                .WithMany(a => a.OrderSelectedMarketers)
                .HasForeignKey(a => a.ModifyUserId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Leads

            modelBuilder.Entity<Lead>()
                .HasOne(a => a.Owner)
                .WithMany(a => a.CollectionLeadOwner)
                .HasForeignKey(a => a.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lead>()
                .HasOne(a => a.CreatedBy)
                .WithMany(a => a.CollectionLeadCreatedBy)
                .HasForeignKey(a => a.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
