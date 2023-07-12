using KanbanTasks.Contracts;
using KanbanTasks.Data;
using KanbanTasks.Models;

namespace KanbanTasks.Repositories
{
  public class SubtaskRepository : RepositoryBase<Subtask>, ISubtaskRepository
  {
    public SubtaskRepository(PostgresContext context) : base(context) { }
  }
}