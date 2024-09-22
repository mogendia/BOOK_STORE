using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOK_STORE.Core.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string  UserName { get; set; }
        public string?  Address { get; set; }
    }
}
