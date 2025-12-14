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
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(Product product) =>
            await _context.Products.AddAsync(product);

        public void Delete(Product product) =>
            _context.Products.Remove(product);
        

        public async Task<bool> Exist(string name) =>
            await _context.Products.FirstOrDefaultAsync(p => string.Equals(p.Name.ToUpper(), name.ToUpper())) != null;
        

        public async Task<IEnumerable<Product>> Get() =>
            await _context.Products.ToListAsync();

        public async Task<Product?> GetById(int id) =>
            await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        public async Task Save() =>
            await _context.SaveChangesAsync();

        public void Update(Product product)
        {
            _context.Products.Attach(product);
            _context.Products.Entry(product).State = EntityState.Modified;
        }
    }
}