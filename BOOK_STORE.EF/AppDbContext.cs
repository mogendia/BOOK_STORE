using BOOK_STORE.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOK_STORE.EF
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books{ get; set; }
        public DbSet<Author> Authors { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
