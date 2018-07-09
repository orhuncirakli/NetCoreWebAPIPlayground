using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class LibraryContext : DbContext
    {
        //public LibraryContext()
        //{

        //}

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.Migrate();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    var contextOptionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
        //    contextOptionsBuilder.UseSqlServer("Server=localhost;Database=LibraryDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    base.OnConfiguring(contextOptionsBuilder);
        //}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
