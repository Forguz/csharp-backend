using Microsoft.EntityFrameworkCore;
using dotenv.net;
using KanbanTasks.Models;

namespace KanbanTasks.Data
{
  public class PostgresContext : DbContext
  {
    public DbSet<Board> Boards { get; set; }
    public DbSet<Column> Columns { get; set; }

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

      modelBuilder.Entity<Board>()
        .HasMany<Column>(b => b.Columns)
        .WithOne(c => c.Board)
        .HasForeignKey(c => c.BoardId);

      modelBuilder.Entity<Column>()
        .Property(c => c.Id)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Column>()
        .Property(c => c.CreatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Column>()
        .Property(c => c.UpdatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Column>()
        .HasOne<Board>(c => c.Board)
        .WithMany(b => b.Columns)
        .HasForeignKey(c => c.BoardId);

      modelBuilder.Entity<Column>()
        .HasMany<Task>(c => c.Tasks)
        .WithOne(t => t.Column)
        .HasForeignKey(t => t.ColumnId);

      modelBuilder.Entity<Task>()
        .Property(t => t.Id)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Task>()
        .Property(t => t.CreatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Task>()
        .Property(t => t.UpdatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Task>()
        .HasOne<Board>(t => t.Board)
        .WithMany(b => b.Tasks)
        .HasForeignKey(t => t.BoardId);

      modelBuilder.Entity<Task>()
        .HasOne<Column>(t => t.Column)
        .WithMany(c => c.Tasks)
        .HasForeignKey(t => t.ColumnId);

      modelBuilder.Entity<Task>()
        .HasMany<Subtask>(t => t.Subtasks)
        .WithOne(s => s.Task)
        .HasForeignKey(s => s.TaskId);

      modelBuilder.Entity<Subtask>()
        .Property(s => s.Id)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Subtask>()
        .Property(s => s.CreatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Subtask>()
        .Property(s => s.UpdatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

      modelBuilder.Entity<Subtask>()
        .HasOne<Task>(s => s.Task)
        .WithMany(t => t.Subtasks)
        .HasForeignKey(s => s.TaskId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      DotEnv.Load();
      var envVars = DotEnv.Read();
      options.UseNpgsql($"Server={envVars["PG_HOST"]};Port={envVars["PG_PORT"]};Database={envVars["PG_DATABASE"]};User ID={envVars["PG_USER"]};Password={envVars["PG_PASS"]}");
    }
  }
}