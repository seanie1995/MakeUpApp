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
        public readonly IProductTypeRepo _productTypeRepo;

        public ProductServices(IProductRepo productRepo, IProductTypeRepo productType)
        {
            _productRepo = productRepo;
            _productTypeRepo = productType;
        }

        public async Task<bool> AddProductAsync(ProductDTO product)
        {
            var productType = await _productTypeRepo.GetProductTypeByIdAsync(product.ProductTypeId);

            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                PAO = product.PAO,
                OpenDate = product.OpenDate,
                ProductType = productType
            };

            var result = await _productRepo.AddProductAsync(newProduct);

            return result;
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
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                PAO = p.PAO,
                OpenDate = p.OpenDate,
                ProductTypeName = p.ProductType.Name
            }
             );
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllUserProductsAsync(string userId)
        {
            var result = await _productRepo.GetUserProductsAsync(userId);

            return result.Select(p => new ProductViewModel
            {
                Id = p.Id,
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

            if (result == null)
            {
                throw new ArgumentException("Object not found");
            }

            ProductViewModel newResult = new ProductViewModel
            {
                Id = id,
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

            var productType = await _productTypeRepo.GetProductTypeByIdAsync(product.ProductTypeId);

            Product updatedProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                PAO = product.PAO,
                OpenDate = product.OpenDate,
                ProductType = productType
            };

            return await _productRepo.UpdateProductAsync(updatedProduct);
        }
    }
}
