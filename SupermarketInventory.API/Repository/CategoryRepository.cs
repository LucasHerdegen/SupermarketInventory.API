using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupermarketInventory.API.Models;

namespace SupermarketInventory.API.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly SupermarketContext _context;

        public CategoryRepository(SupermarketContext context)
        {
            _context = context;
        }

        public async Task Add(Category category) =>
            await _context.Categories.AddAsync(category);
        
        public async Task<IEnumerable<Category>> Get() =>
            await _context.Categories.AsNoTracking().ToListAsync();

        public async Task<Category?> GetById(int id) =>
            await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task Save() =>
            await _context.SaveChangesAsync();

        public async Task<bool> Exist(string name) => 
            await _context.Categories.AnyAsync(c => string.Equals(c.Name!.ToUpper(), name.ToUpper()));

        public async Task<bool> CategoryExist(int id) => 
            await _context.Categories.AnyAsync(c => c.Id == id);
    }
}