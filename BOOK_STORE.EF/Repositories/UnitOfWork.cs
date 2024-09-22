using BOOK_STORE.Core.Interfaces;
using BOOK_STORE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOK_STORE.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository Authors { get; private set; }
        public IBookRepository Books { get; private set; }




        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context ;
            Authors = new AuthorRepository(context);
            Books = new BookRepository(context);
        }


        public int complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
