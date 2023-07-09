using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedAtTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS moddatetime;");
            migrationBuilder.Sql(@"
                CREATE TRIGGER BoardsUpdatedAt
                BEFORE UPDATE ON boards
                FOR EACH ROW
                EXECUTE PROCEDURE moddatetime (updated_at);");

            migrationBuilder.Sql(@"
                CREATE TRIGGER ColumnsUpdatedAt
                BEFORE UPDATE ON columns
                FOR EACH ROW
                EXECUTE PROCEDURE moddatetime (updated_at);");

            migrationBuilder.Sql(@"
                CREATE TRIGGER TasksUpdatedAt
                BEFORE UPDATE ON tasks
                FOR EACH ROW
                EXECUTE PROCEDURE moddatetime (updated_at);");

            migrationBuilder.Sql(@"
                CREATE TRIGGER SubtasksUpdatedAt
                BEFORE UPDATE ON subtasks
                FOR EACH ROW
                EXECUTE PROCEDURE moddatetime (updated_at);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS SubtasksUpdatedAt ON subtasks;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS TasksUpdatedAt ON tasks;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS ColumnsUpdatedAt ON columns;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS BoardsUpdatedAt ON boards;");
            migrationBuilder.Sql("DROP EXTENSION IF EXISTS moddatetime;");
        }
    }
}
