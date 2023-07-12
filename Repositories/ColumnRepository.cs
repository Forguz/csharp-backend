using KanbanTasks.Contracts;
using KanbanTasks.Data;
using KanbanTasks.Models;

namespace KanbanTasks.Repositories
{
  public class ColumnRepository : RepositoryBase<Column>, IColumnRepository
  {
    public ColumnRepository(PostgresContext context) : base(context) { }

  }
}