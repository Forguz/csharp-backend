using KanbanTasks.Contracts;
using KanbanTasks.Data;
using KanbanTasks.Models;

namespace KanbanTasks.Repositories
{
  public class BoardRepository : RepositoryBase<Board>, IBoardRepository
  {
    public BoardRepository(PostgresContext context) : base(context) { }
  }
}