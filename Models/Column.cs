using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanTasks.Models
{
  [Table("columns")]
  public class Column
  {
    [Column("column_id", TypeName = "UUID")]
    public Guid ColumnId { get; set; }

    [Column("title", TypeName = "varchar(50)"), Required]
    public string Title { get; set; }

    [Column("board_id", TypeName = "UUID")]
    public Guid BoardId { get; set; }

    public Board Board { get; set; }

    [Column("created_at"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
  }
}