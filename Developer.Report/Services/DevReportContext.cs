using Developer.Report.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Developer.Report.Services
{
    public class DevReportContext : DbContext
    {
        public DevReportContext(DbContextOptions<DevReportContext> options) : base(options)
        {

        }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DeveloperCoder> Developers { get; set; }
    }
}
