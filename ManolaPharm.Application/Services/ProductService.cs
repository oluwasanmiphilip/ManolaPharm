using ManolaPharm.Application.DTOs.ProductDtos;
using ManolaPharm.Domain.Entities.Product;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _context.Set<Product>().ToListAsync();
            return products.Select(p => new ProductDto
            {
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                Manufacturer = p.Manufacturer,
                BatchNumber = p.BatchNumber,
                ExpiryDate = p.ExpiryDate,
                UnitPrice = p.UnitPrice,
                QuantityPerPack = p.QuantityPerPack,
                ReorderLevel = p.ReorderLevel,
               
            });
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var p = await _context.Set<Product>().FindAsync(id);
            if (p == null) return null;

            return new ProductDto
            {
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                Manufacturer = p.Manufacturer,
                BatchNumber = p.BatchNumber,
                ExpiryDate = p.ExpiryDate,
                UnitPrice = p.UnitPrice,
                QuantityPerPack = p.QuantityPerPack,
                ReorderLevel = p.ReorderLevel,
                
            };
        }

        public async Task<bool> CreateAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Manufacturer = dto.Manufacturer,
                BatchNumber = dto.BatchNumber,
                ExpiryDate = dto.ExpiryDate,
                UnitPrice = dto.UnitPrice,
                QuantityPerPack = dto.QuantityPerPack,
                ReorderLevel = dto.ReorderLevel,
                IsActive = true
            };

            await _context.Set<Product>().AddAsync(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, ProductUpdateDto dto)
        {
            var product = await _context.Set<Product>().FindAsync(id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Category = dto.Category;
            product.Manufacturer = dto.Manufacturer;
            product.BatchNumber = dto.BatchNumber;
            product.ExpiryDate = dto.ExpiryDate;
            product.UnitPrice = dto.UnitPrice;
            product.QuantityPerPack = dto.QuantityPerPack;
            product.ReorderLevel = dto.ReorderLevel;
            product.IsActive = dto.IsActive;

            _context.Set<Product>().Update(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _context.Set<Product>().FindAsync(id);
            if (product == null) return false;

            _context.Set<Product>().Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
