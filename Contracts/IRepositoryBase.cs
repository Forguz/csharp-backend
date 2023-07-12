using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KanbanTasks.Contracts
{
  public interface IRepositoryBase<T>
  {
    Task<List<T>> FindAll();
    Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression);
    Task<T> FindById(Guid id);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(Guid id);
  }
}