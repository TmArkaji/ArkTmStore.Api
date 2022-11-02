using System;
using ArkTmStore.Api.BdContext;
using ArkTmStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ArkTmStore.Api.Repository
{
    public class ProductoRepository : BaseRepository<int, Product>, IProductoRepository
    {

        public ProductoRepository(ApplicationDbContext db) : base(db)
        {
        }

        public new async Task<IEnumerable<Product>> GetAll()
        {
            return await _db.Product.Where(m => m.deleted == false)
                .OrderBy(m => m.productName)
                .Include(m => m.Color)
                .Include(m => m.Category)
                .Include(m => m.Brand)
                .ToListAsync();
        }
    }
}

