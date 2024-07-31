using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Domain.Entities.Account;
using MyCrm.Domain.Entities.Companies;
using MyCrm.Domain.Entities.Events;
using MyCrm.Domain.Entities.Orders;

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
        public DbSet<Customer> Cursomers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderSelectedMarketer> OrderSelectedMarketers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Event>  Events { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region fluent

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

            #endregion

        }
    }
}
