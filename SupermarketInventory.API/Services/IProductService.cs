using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketInventory.API.DTOs;

namespace SupermarketInventory.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task<ProductDto> AddProduct(ProductPostDto product);
        Task<ProductDto> UpdateProduct(ProductPutDto product);
        Task<ProductDto> DeleteProduct(int id);
    }
}