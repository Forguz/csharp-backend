using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanTasks.Models
{
  [Table("tasks")]
  public class Task
  {
    [Column("task_id", TypeName = "UUID")]
    public Guid TaskId { get; set; }

    [Column("column_id", TypeName = "UUID")]
    public Guid ColumnId { get; set; }
    public Column Column { get; set; }

    [Column("board_id", TypeName = "UUID")]
    public Guid BoardId { get; set; }
    public Board Board { get; set; }

    [Column("title", TypeName = "varchar(50)"), Required]
    public string Title { get; set; }

    [Column("description", TypeName = "text")]
    public string Description { get; set; }

    [Column("created_at"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
  }
}