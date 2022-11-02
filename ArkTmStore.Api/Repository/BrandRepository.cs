using System;
using ArkTmStore.Api.BdContext;
using ArkTmStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ArkTmStore.Api.Repository
{
    public class BrandRepository : BaseRepository<int, Brand>, IBrandRepository
    {

        public BrandRepository(ApplicationDbContext db) : base(db)
        {
        }

        public new async Task<IEnumerable<Brand>> GetAll()
        {
            return await _db.Brand.Where(m => m.deleted == false)
                .OrderBy(m => m.brand)
                .ToListAsync();
        }
    }
}

