using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Domain.Entities.Account;

namespace MyCrm.Data
{
    public class CrmContext : DbContext
    {
        public CrmContext(DbContextOptions<CrmContext> options): base(options)
        {
        }
        #region DB Set
        public DbSet<User> Users { get; set; }
        public DbSet<Marketer> Marketers { get; set; }
        public DbSet<Customer> Cursomers { get; set; }
        #endregion
    }
}
