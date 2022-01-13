using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAppThree.Models;

namespace TestAppThree.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TestAppThree.Models.Customer> Customer { get; set; }
        public DbSet<NewsItem> NewsItems { get; set; }
    }
}
