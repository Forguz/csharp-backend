using Microsoft.EntityFrameworkCore;
using dotenv.net;
using KanbanTasks.Models;

namespace KanbanTasks.Data
{
  public class PostgresContext : DbContext
  {
    public DbSet<Board> Boards { get; set; }
    public DbSet<Column> Columns { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Addd the Postgres Extension for UUID generation
      modelBuilder.HasPostgresExtension("uuid-ossp");

      modelBuilder.Entity<Board>()
        .Property(b => b.BoardId)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Column>()
        .Property(c => c.ColumnId)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Task>()
        .Property(t => t.TaskId)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Subtask>()
        .Property(s => s.SubtaskId)
        .HasDefaultValueSql("uuid_generate_v4()");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      DotEnv.Load();
      var envVars = DotEnv.Read();
      options.UseNpgsql($"Server={envVars["PG_HOST"]};Port={envVars["PG_PORT"]};Database={envVars["PG_DATABASE"]};User ID={envVars["PG_USER"]};Password={envVars["PG_PASS"]}");
    }
  }
}