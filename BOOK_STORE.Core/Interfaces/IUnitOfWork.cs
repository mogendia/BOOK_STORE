using BOOK_STORE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOK_STORE.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors {  get; }
        IBookRepository Books { get; }


        int complete();
    }
}
