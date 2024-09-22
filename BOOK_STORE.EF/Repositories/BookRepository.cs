using BOOK_STORE.Core.Dto;
using BOOK_STORE.Core.Interfaces;
using BOOK_STORE.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE.EF.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Book AddBook(BookDto model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                AuthorId = model.AuthorId,
                Description = model.Description
                
            };
            _context.Books.Add(book);        
            return book;
        }

        public Book UpdateBook(BookDto bookDto)
        {
            var edit = _context.Books.Find(bookDto.Id);
            if (edit == null)
                throw new Exception("In-valid Id");
            edit.Title = bookDto.Title;
            edit.AuthorId = bookDto.AuthorId;
            //edit.Description = bookDto.Description;
            return edit;

        }
    }
}
