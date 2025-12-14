using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketInventory.API.DTOs;

namespace SupermarketInventory.API.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductDto> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> AddProduct(ProductPostDto product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> UpdateProduct(ProductPutDto product)
        {
            throw new NotImplementedException();
        }
    }
}