﻿using MakeUpApp.Models.DTOs.ProductTypeDTOs;
using MakeUpApp.Models.ViewModels;

namespace MakeUpApp.Services.IServices
{
    public interface IProductTypeServices
    {
        Task<bool> AddProductTypeAsync(ProductTypeCreateDTO productType);
        Task<ProductTypeViewModel> GetProductTypeByIdAsync(int id);
        Task<IEnumerable<ProductTypeViewModel>> GetAllProductTypesAsync();
        Task<bool> UpdateProductTypeAsync(ProductTypeDTO product);
        Task<bool> DeleteProductTypeAsync(int id);
    }
}
