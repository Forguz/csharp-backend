using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanTasks.Models
{
  [Table("tasks")]
  public class Task
  {
    [Column("id", TypeName = "UUID")]
    public Guid Id { get; set; }

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

    public ICollection<Subtask> Subtasks { get; set; } = new List<Subtask>();

    [DataType(DataType.DateTime)]
    [Column("created_at"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DataType(DataType.DateTime)]
    [Column("updated_at"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime UpdatedAt { get; set; }
  }
}