using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanTasks.Models
{
  [Table("boards")]
  public class Board
  {
    [Column("board_id", TypeName = "UUID")]
    public Guid BoardId { get; set; }

    [Column("title", TypeName = "varchar(50)"), Required]
    public string Title { get; set; }

    public ICollection<Column> Columns { get; } = new List<Column>();
    public ICollection<Task> Tasks { get; } = new List<Task>();

    [Column("created_at"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
  }
}