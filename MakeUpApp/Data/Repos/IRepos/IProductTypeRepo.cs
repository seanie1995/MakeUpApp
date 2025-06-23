using MakeUpApp.Models;

namespace MakeUpApp.Data.Repos.IRepos
{
    public interface IProductTypeRepo
    {
        Task<bool> AddProductTypeAsync(ProductType productType);
        Task<ProductType?> GetProductTypeByIdAsync(int id);
        Task<IEnumerable<ProductType>> GetAllProductTypesAsync();

        Task<bool> UpdateProductTypeAsync(ProductType updatedProductType);
        Task<bool> DeleteProductTypeAsync(int id);
    }
}
