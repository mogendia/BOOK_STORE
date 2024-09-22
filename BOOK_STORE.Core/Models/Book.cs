using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOK_STORE.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required , MaxLength(50)]
        public string Title { get; set; }
        [ MaxLength(200)]

        public string Description { get; set; }

        public Author? Author { get; set; }
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
    }
}
