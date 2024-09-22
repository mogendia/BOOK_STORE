using BOOK_STORE.Core.Dto;
using BOOK_STORE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOK_STORE.Core.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Author AddAuthor(AuthorDto author);
        Author UpdateAuthor(AuthorDto author);

    }
}
