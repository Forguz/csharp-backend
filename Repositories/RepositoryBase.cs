using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KanbanTasks.Contracts;
using KanbanTasks.Data;
using Microsoft.EntityFrameworkCore;

namespace KanbanTasks.Repositories
{
  public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    protected PostgresContext _context;

    public RepositoryBase(PostgresContext context)
    {
      _context = context;
    }

    public async Task<List<T>> FindAll()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression)
    {
      return await _context.Set<T>().Where(expression).ToListAsync();
    }

    public async Task<T> FindById(Guid id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> Create(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task<T> Update(T entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task<T> Delete(Guid id)
    {
      var entity = await this.FindById(id);
      if (entity == null)
      {
        return entity;
      }

      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();

      return entity;
    }
  }
}