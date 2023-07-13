using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KanbanTasks.Contracts;
using KanbanTasks.Data;
using KanbanTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanTasks.Repositories
{
  public class BoardRepository : RepositoryBase<Board>, IBoardRepository
  {
    public BoardRepository(PostgresContext context) : base(context) { }

    public override async Task<List<Board>> FindAll()
    {
      return await _context.Boards
          .Include(b => b.Columns)
          .Include(b => b.Tasks)
          .ToListAsync();
    }

    public override async Task<Board> FindById(Guid id)
    {
      return await _context.Boards
          .Include(b => b.Columns)
          .Include(b => b.Tasks)
          .SingleAsync(b => b.Id == id);
    }
  }
}