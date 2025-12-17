using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupermarketInventory.API.Models;

namespace SupermarketInventory.API.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly SupermarketContext _context;

        public ProductRepository(SupermarketContext context)
        {
            _context = context;
        }

        public async Task Add(Product product) =>
            await _context.Products.AddAsync(product);

        public void Delete(Product product) =>
            _context.Products.Remove(product);
        

        public async Task<bool> Exist(string name) =>
            await _context.Products.AnyAsync(p => string.Equals(p.Name!.ToUpper(), name.ToUpper()));
        
        public async Task<bool> CategoryExist(int id) =>
            await _context.Categories.AnyAsync(c => c.Id == id);

        public async Task<IEnumerable<Product>> Get() =>
            await _context.Products.Include(p => p.Category).AsNoTracking().ToListAsync();

        public async Task<Product?> GetById(int id) =>
            await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

        public async Task Save() =>
            await _context.SaveChangesAsync();

        public void Update(Product product) =>
            _context.Products.Update(product);
        
    }
}