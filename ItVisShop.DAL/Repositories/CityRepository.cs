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
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationContext _db;

        public CityRepository(ApplicationContext db)
        {
            _db = db;
        }

        // Получение всех городов.
        public async Task<List<City>> GetCities()
        {
            return await _db.Cities.ToListAsync();
        }
    }
}
