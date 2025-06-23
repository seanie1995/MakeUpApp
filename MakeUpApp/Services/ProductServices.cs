using MakeUpApp.Data.Repos.IRepos;
using MakeUpApp.Models;
using MakeUpApp.Models.DTOs.ProductDTOs;
using MakeUpApp.Models.ViewModels;
using MakeUpApp.Services.IServices;

namespace MakeUpApp.Services
{
    public class ProductServices : IProductServices
    {
        public readonly IProductRepo _productRepo;

        public ProductServices(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public Task<bool> AddProductAsync(ProductDTO product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                PAO = product.PAO,
                OpenDate = product.OpenDate,
                ProductType = product.ProductType,
            };

            return _productRepo.AddProductAsync(newProduct);
            
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            return _productRepo.DeleteProductAsync(id);
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            var result = await _productRepo.GetAllProductsAsync();

            return result.Select(p => new ProductViewModel
            {
                Name = p.Name,
                Description = p.Description,
                PAO = p.PAO,
                OpenDate = p.OpenDate,
                ProductTypeName = p.ProductType.Name
            }
             );
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllUserProductsAsync(int userId)
        {
            var result = await _productRepo.GetUserProductsAsync(userId);

            return result.Select(p => new ProductViewModel
            {
                Name = p.Name,
                Description = p.Description,
                PAO = p.PAO,
                OpenDate = p.OpenDate,
                ProductTypeName = p.ProductType.Name
            });

        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            var result = await _productRepo.GetProductByIdAsync(id);

            ProductViewModel newResult = new ProductViewModel
            {
                Name = result.Name,
                Description = result.Description,
                PAO = result.PAO,
                OpenDate = result.OpenDate,
                ProductTypeName = result.ProductType.Name
            };
            return newResult;
        }

        public async Task<bool> UpdateProductAsync(ProductDTO product)
        {

            Product updatedProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                PAO = product.PAO,
                OpenDate = product.OpenDate,
                ProductType = product.ProductType,
            };

            return await _productRepo.UpdateProductAsync(updatedProduct);
        }
    }
}
