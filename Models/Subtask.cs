using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanTasks.Models
{
  [Table("subtasks")]
  public class Subtask
  {
    [Column("id", TypeName = "UUID")]
    public Guid Id { get; set; }

    [Column("task_id", TypeName = "UUID")]
    public Guid TaskId { get; set; }

    [Column("title", TypeName = "varchar(255)"), Required]
    public string Title { get; set; }

    [Column("is_done", TypeName = "boolean"), Required]
    public bool IsDone { get; set; }

    [Column("created_at"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }
  }
}