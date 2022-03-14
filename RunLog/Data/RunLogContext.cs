using Microsoft.EntityFrameworkCore;
using RunLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Data
{
    public class RunLogContext: DbContext
    {
        public DbSet<Run> Runs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1TF0AJT;Initial Catalog=RunLogDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; User Id=run_log_backend; Password=run_log_backend_password");
        }

    }
}
