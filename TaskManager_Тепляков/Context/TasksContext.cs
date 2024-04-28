using Microsoft.EntityFrameworkCore;

namespace TaskManager_Тепляков.Context
{
    public class TasksContext : DbContext
    {
        public DbSet<Models.Tasks> Tasks { get; set; }

        public TasksContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Classes.Database.Config.connection, Classes.Database.Config.version);
    }
}
