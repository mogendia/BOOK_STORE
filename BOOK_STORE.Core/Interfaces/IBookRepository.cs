using BOOK_STORE.Core.Dto;
using BOOK_STORE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOK_STORE.Core.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Book AddBook(BookDto bookDto);
        Book UpdateBook(BookDto bookDto);


    }
}
