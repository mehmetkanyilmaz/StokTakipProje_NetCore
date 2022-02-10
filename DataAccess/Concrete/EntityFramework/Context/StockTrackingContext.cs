using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class StockTrackingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog=STOCK_TRACKING_DB; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<City> TBL_CITY { get; set; }
        public DbSet<District> TBL_DISTRICT { get; set; }
        public DbSet<User> TBL_USER { get; set; }
        public DbSet<Customer> TBL_CUSTOMER { get; set; }
        public DbSet<Stock> TBL_STOCK { get; set; }
        public DbSet<Stock_Group> TBL_STOCK_GROUP { get; set; }
        public DbSet<Stock_Move> TBL_STOCK_MOVE { get; set; }
        public DbSet<Stock_Brand> TBL_STOCK_BRAND { get; set; }
        public DbSet<Stock_Model> TBL_STOCK_MODEL { get; set; }
    }
}
