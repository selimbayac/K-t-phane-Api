using Data.Context;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly KutuphaneDbContext _context;
        public UserRepository(KutuphaneDbContext kutuphaneDbContext)
        {
            _context = kutuphaneDbContext;
        }
        public async Task AddUserAsync(User user)
        {
           _context.Kullanici.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Kullanici.FindAsync(id);
            if (user != null) // buna bak anlamadım ilk bakışta malım sanırım 
            {
                _context.Kullanici.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_context.Kullanici.ToList());
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
          return await _context.Kullanici.FindAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Kullanici.Update(user);
             await _context.SaveChangesAsync();
        }
    }
}
