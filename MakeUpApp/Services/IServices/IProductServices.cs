using MakeUpApp.Models.DTOs.ProductDTOs;
using MakeUpApp.Models.ViewModels;

namespace MakeUpApp.Services.IServices
{
    public interface IProductServices
    {
        Task<bool> AddProductAsync(ProductCreateDTO product);
        Task<ProductViewModel> GetProductByIdAsync(int id);

        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();

        Task<IEnumerable<ProductViewModel>> GetAllUserProductsAsync(string userId);
        Task<bool> UpdateProductAsync (ProductDTO product);
        Task<bool> DeleteProductAsync (int id);

    }
}
