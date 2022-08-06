using OnionArch.Data.DTOs;
using OnionArch.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Data.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync(ProductFilterDto productFilterDto);
        Task<Product> GetProductByIdAsync(Guid productID);
        Task<List<ProductType>> GetProductTypesAsync();
        Task<double> CalculateDiscountOnProductItems(Guid productId, int itemsCount);

    }
}
