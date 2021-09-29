using Prova.Csharp.Data;
using Prova.Csharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Csharp.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DataContext _context;

        public BooksRepository(DataContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            book.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(book.Name))
                throw new ArgumentNullException(nameof(Book.Name), "O nome do livro é obrigatório");

            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }
        
        public IEnumerable<Book> GetAll() => _context.Books.ToList();

        public Book GetById(Guid id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }
    }
}
