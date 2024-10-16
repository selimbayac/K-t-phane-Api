using AutoMapper;
using Business.IService;
using Data.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        public BookService(IBookRepository bookRepository, IUserRepository userRepository )
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
       

        }
        public async Task AddBookAsync(Book user)
        {
           await _bookRepository.AddBookAsync(user);
        }

        public async Task DeleteBookAsync(int id)
        {
            var result = await _bookRepository.GetBookByIdAsync(id); // await ekledik
            if (result != null)
            {
                await _bookRepository.DeleteBookAsync(id);
            }
        }

        public async Task<IEnumerable<Book>> GetAllBookAsync()
        {
          return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
          return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task UpdateBookAsync(Book user)
        {
            await _bookRepository.UpdateBookAsync(user);
        }
        public async Task PurchaseBookAsync(int bookId, int userId)
        {
            // 1. Kitabı bul
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            if (book == null || book.Adet <= 0)
            {
                throw new InvalidOperationException("Kitap bulunamadı veya stokta yok.");
            }

            // 2. Kitap sayısını eksilt
            book.Adet--;

            // 3. Kitap veritabanında güncellenir
            await _bookRepository.UpdateBookAsync(book);

            // 4. Kullanıcının satın aldığı kitaplara ekle
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user != null)
            {
                user.Purchased += book.KitapAdi + "; "; // Satın alınan kitapları ekliyoruz
                await _userRepository.UpdateUserAsync(user);
            }
        }
    }
}
