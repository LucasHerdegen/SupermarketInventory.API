using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}