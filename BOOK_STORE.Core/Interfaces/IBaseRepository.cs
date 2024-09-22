using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BOOK_STORE.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task <T?> GetById(int id);
        Task<IEnumerable<T?>> GetAll();

        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<T>CreateOne(T entity);
        T UpdateOne(T entity);
        bool DeleteOne(int id);




    }
}

