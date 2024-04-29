using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager_Тепляков.Context
{
    public class PriorityContext : DbContext
    {
        public DbSet<Models.Priority> Priority { get; set; }

        public PriorityContext()
        {
            Database.EnsureCreated();
            Priority.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Classes.Database.Config.connection, Classes.Database.Config.version);
    }
}
