using Microsoft.EntityFrameworkCore;
using NikaScrapApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Infrastructure.Context
{
    internal class DigitalKabadiDbContext : DbContext
    {
        public DigitalKabadiDbContext()
        {
        }
        public DigitalKabadiDbContext(DbContextOptions<DigitalKabadiDbContext> option) : base(option)
        {
            //SeedData();
        } 
        public virtual DbSet<Users> Users { get; set; } 
    }
}
