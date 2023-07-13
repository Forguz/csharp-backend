using System.Collections.Generic;
using KanbanTasks.Contracts;
using KanbanTasks.Data;
using KanbanTasks.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace KanbanTasks.Repositories
{
  public class TaskRepository : RepositoryBase<Models.Task>, ITaskRepository
  {
    public TaskRepository(PostgresContext context) : base(context) { }

    public async override Task<List<Models.Task>> FindAll()
    {
      return await _context.Tasks.Include(t => t.Subtasks).ToListAsync();
    }

    public async override Task<Models.Task> FindById(Guid id)
    {
      return await _context.Tasks.Include(t => t.Subtasks).SingleAsync(t => t.Id == id);
    }
  }
}