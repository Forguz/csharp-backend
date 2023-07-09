using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanTasks.Models
{
  [Table("subtasks")]
  public class Subtask
  {
    [Column("subtask_id", TypeName = "UUID")]
    public Guid SubtaskId { get; set; }

    [Column("task_id", TypeName = "UUID")]
    public Guid TaskId { get; set; }
    public Task Task { get; set; }

    [Column("title", TypeName = "varchar(255)"), Required]
    public string Title { get; set; }

    [Column("is_done", TypeName = "boolean"), Required]
    public bool Description { get; set; }

    [Column("created_at"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
  }
}