using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IService
{
    public interface IBookService
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBookAsync();
        Task AddBookAsync(Book user);
        Task UpdateBookAsync(Book user);
        Task DeleteBookAsync(int id);
        Task PurchaseBookAsync(int bookId, int userId); // satın almayı unuttum şimdi ekliyom 
    }
}
