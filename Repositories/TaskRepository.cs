using KanbanTasks.Contracts;
using KanbanTasks.Data;
using KanbanTasks.Models;

namespace KanbanTasks.Repositories
{
  public class TaskRepository : RepositoryBase<Task>, ITaskRepository
  {
    public TaskRepository(PostgresContext context) : base(context) { }
  }
}