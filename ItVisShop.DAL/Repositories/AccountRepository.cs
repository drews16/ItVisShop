using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _db;

        public AccountRepository(ApplicationContext db)
        {
            _db = db;
        }

        // Создание пользователя.
        public async Task<bool> Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public Task<bool> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        //Получение всех пользователей.
        public async Task<List<User>> Select()
        {
            return await _db.Users.ToListAsync();
        }
    }
}
