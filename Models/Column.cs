using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanTasks.Models
{
  [Table("columns")]
  public class Column
  {
    [Column("id", TypeName = "UUID")]
    public Guid Id { get; set; }

    [Column("title", TypeName = "varchar(50)"), Required]
    public string Title { get; set; }

    [Column("board_id", TypeName = "UUID")]
    public Guid BoardId { get; set; }

    public ICollection<Task> Tasks { get; set; } = new List<Task>();

    [Column("created_at"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }
  }
}