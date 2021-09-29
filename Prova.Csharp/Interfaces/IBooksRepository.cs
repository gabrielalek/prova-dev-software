using Prova.Csharp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Csharp.Interfaces
{
    public interface IBooksRepository
    {
        Book GetById(Guid id);
        IEnumerable<Book> GetAll();
        Book Create(Book book);
    }
}
