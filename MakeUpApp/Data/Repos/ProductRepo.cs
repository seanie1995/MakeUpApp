using MakeUpApp.Data.Repos.IRepos;
using MakeUpApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MakeUpApp.Data.Repos
{
    public class ProductRepo : IProductRepo
    {
        public readonly MakeupContext _context;

        public ProductRepo(MakeupContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database error at Repo level", ex);
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {

            try
            {
                var found = await _context.Products.FindAsync(id);
                if (found != null)
                {
                    _context.Remove(found);
                }
                else if (found == null)
                {
                    return false;
                }
              
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Database error at Repo level", ex);     
            }   
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {    
            try
            {
               return await _context.Products.ToListAsync();
           
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Database error at Repo level", ex);
            }
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            try
            {
                return await _context.Products.
                    Include(p => p.ProductType)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Database error at Repo level", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetUserProductsAsync(string id)
        {
            try
            {
                var foundList = await _context.Products
                    .Where(p => p.UserId == id)
                    .ToListAsync();

                return foundList;
                
            }
            catch (Exception ex) { throw new ApplicationException(ex.Message, ex); }
        }

        public async Task<bool> UpdateProductAsync(Product updatedProduct)
        {
            try
            {
                _context.Products.Update(updatedProduct);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Database error at repo level", ex);
            }
        }
    }
}
