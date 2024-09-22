using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BOOK_STORE.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BOOK_STORE.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private  AppDbContext _context { get; set; }

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task <T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
             
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> CreateOne(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public  T UpdateOne(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChangesAsync();
            return entity;
        }

        public bool DeleteOne(int id)
        {
            var IsDeleted = _context.Set<T>().Find(id);
            if (IsDeleted !=null)
            {
                _context.Set<T>().Remove(IsDeleted);
                return true;
            }
            return false;
        }


        public T Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return query.SingleOrDefault(match);
        }



        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
             return query.Where(match).ToList();
        }

       
    }
}
