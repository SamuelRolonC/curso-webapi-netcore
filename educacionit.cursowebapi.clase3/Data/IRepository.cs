using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace educacionit.cursowebapi.clase3.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        T Add(T entity);
        Task<T> AddAsync(T entity);

        T Update(T entity);
        Task<T> UpdateAsync(T entity);

        T Remove(int id);
        Task<T> RemoveAsync(int id);
    }
}
