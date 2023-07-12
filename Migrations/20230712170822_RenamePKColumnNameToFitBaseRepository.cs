using System;
using KanbanTasks.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_backend.Migrations
{
    /// <inheritdoc />
    public partial class RenamePKColumnNameToFitBaseRepository : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                table: "boards",
                name: "board_id",
                newName: "id"
            );

            migrationBuilder.RenameColumn(
                table: "columns",
                name: "column_id",
                newName: "id"
            );

            migrationBuilder.RenameColumn(
                table: "tasks",
                name: "task_id",
                newName: "id"
            );

            migrationBuilder.RenameColumn(
                table: "subtasks",
                name: "subtask_id",
                newName: "id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                table: "subtasks",
                name: "id",
                newName: "subtask_id"
            );
            migrationBuilder.RenameColumn(
                table: "tasks",
                name: "id",
                newName: "task_id"
            );
            migrationBuilder.RenameColumn(
                table: "columns",
                name: "id",
                newName: "column_id"
            );
            migrationBuilder.RenameColumn(
                table: "boards",
                name: "id",
                newName: "board_id"
            );
        }
    }
}
