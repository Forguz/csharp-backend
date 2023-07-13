using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KanbanTasks.Contracts;
using KanbanTasks.Data;
using KanbanTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanTasks.Repositories
{
  public class ColumnRepository : RepositoryBase<Column>, IColumnRepository
  {
    public ColumnRepository(PostgresContext context) : base(context) { }

    public async override Task<List<Column>> FindAll()
    {
      return await _context.Columns
          .Include(b => b.Tasks)
          .ToListAsync();
    }

    public async override Task<Column> FindById(Guid id)
    {
      return await _context.Columns
          .Include(c => c.Tasks)
          .SingleAsync(c => c.Id == id);
    }
  }
}