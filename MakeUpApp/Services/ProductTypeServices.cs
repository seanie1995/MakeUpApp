using MakeUpApp.Data.Repos.IRepos;
using MakeUpApp.Models;
using MakeUpApp.Models.DTOs.ProductDTOs;
using MakeUpApp.Models.ViewModels;
using MakeUpApp.Services.IServices;

namespace MakeUpApp.Services
{
    public class ProductTypeServices : IProductTypeServices
    {
        public readonly IProductTypeRepo _productTypeRepo;

        public ProductTypeServices(IProductTypeRepo repo)
        {
            _productTypeRepo = repo;
        }
        public async Task<bool> AddProductTypeAsync(ProductTypeDTO productType)
        {
            ProductType newProdType = new ProductType
            {

                Name = productType.Name,
            };

            return await _productTypeRepo.AddProductTypeAsync(newProdType);
        }

        public async Task<bool> DeleteProductTypeAsync(int id)
        {
            return await _productTypeRepo.DeleteProductTypeAsync(id);
        }


        public async Task<IEnumerable<ProductTypeViewModel>> GetAllProductTypesAsync()
        {
            var result = await _productTypeRepo.GetAllProductTypesAsync();

            ProductTypeViewModel[] resultList = result.Select(p => new ProductTypeViewModel
            {
                Id = p.Id,
                Name = p.Name,
            }).ToArray();
            
            return resultList;
        }

        public async Task<ProductTypeViewModel> GetProductTypeByIdAsync(int id)
        {
            var result = await _productTypeRepo.GetProductTypeByIdAsync(id);

            ProductTypeViewModel viewModel = new ProductTypeViewModel
            {
                Id = result.Id,
                Name = result.Name
            };

            return viewModel;
        }

        public async Task<bool> UpdateProductTypeAsync(ProductTypeDTO product)
        {
            ProductType newProductType = new ProductType { Name = product.Name, };

            return await _productTypeRepo.UpdateProductTypeAsync(newProductType);
        }

    }
}
