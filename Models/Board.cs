using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanTasks.Models
{
  [Table("boards")]
  public class Board
  {
    [Column("id", TypeName = "UUID")]
    public Guid Id { get; set; }

    [Column("title", TypeName = "varchar(50)"), Required]
    public string Title { get; set; }

    public ICollection<Column> Columns { get; set; } = new List<Column>();
    public ICollection<Task> Tasks { get; set; } = new List<Task>();

    [Column("created_at"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }
  }
}