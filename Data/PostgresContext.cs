using Microsoft.EntityFrameworkCore;
using dotenv.net;
using KanbanTasks.Models;

namespace KanbanTasks.Data
{
  public class PostgresContext : DbContext
  {
    public DbSet<Board> Boards { get; set; }
    public DbSet<Column> Columns { get; set; }

    public DbSet<Task> Tasks { get; set; }

    public DbSet<Subtask> Subtasks { get; set; }

    public PostgresContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Addd the Postgres Extension for UUID generation
      modelBuilder.HasPostgresExtension("uuid-ossp");
      modelBuilder.HasPostgresExtension("moddatetime");

      modelBuilder.Entity<Board>()
        .Property(b => b.Id)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Board>()
        .Property(b => b.CreatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Board>()
        .Property(b => b.UpdatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Column>()
        .Property(c => c.Id)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Column>()
        .Property(c => c.CreatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Column>()
        .Property(c => c.UpdatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Task>()
        .Property(t => t.Id)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Task>()
        .Property(t => t.CreatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Task>()
        .Property(t => t.UpdatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Subtask>()
        .Property(s => s.Id)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Subtask>()
        .Property(s => s.CreatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Subtask>()
        .Property(s => s.UpdatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      DotEnv.Load();
      var envVars = DotEnv.Read();
      options.UseNpgsql($"Server={envVars["PG_HOST"]};Port={envVars["PG_PORT"]};Database={envVars["PG_DATABASE"]};User ID={envVars["PG_USER"]};Password={envVars["PG_PASS"]}");
    }
  }
}