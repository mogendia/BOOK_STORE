using BOOK_STORE.Core.Dto;
using BOOK_STORE.Core.Interfaces;
using BOOK_STORE.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOK_STORE.EF.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Author AddAuthor(AuthorDto dto)
        {
            Author author = new Author
            {
                UserName = dto.Name,
                Id = dto.Id
            };
            _context.Authors.Add(author);
            return author;
        }

        public Author UpdateAuthor(AuthorDto author)
        {
            var authorrs = _context.Authors.Find(author.Id);
            if (authorrs == null)
                throw new Exception("In-Valid Id");
            authorrs.UserName = author.Name;
            _context.Authors.Update(authorrs);
            return authorrs;
        }
    }
}

