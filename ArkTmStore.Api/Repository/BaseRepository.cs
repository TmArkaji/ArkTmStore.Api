using System;
using ArkTmStore.Api.BdContext;
using ArkTmStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ArkTmStore.Api.Repository
{

    public class BaseRepository<TKey, TModel> : IBaseRepository<TKey, TModel>
        where TModel : BaseModel<TKey>
    {
        protected readonly ApplicationDbContext _db;

        public BaseRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            return await _db.Set<TModel>().Where(m => !m.deleted).ToListAsync();
        }

        
        public virtual Task<TModel> GetById(TKey id)
        {
            return Task.FromResult(_db.Set<TModel>().Find(id));
        }
        public async Task Insert(TModel model)
        {
            model.deleted = false;
            model.createDate = DateTime.Now;
            _db.Set<TModel>().Add(model);
            await _db.SaveChangesAsync();
        }

        public virtual async Task Update(TModel model)
        {
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public virtual async Task DeleteById(TKey id)
        {
            TModel? model = _db.Set<TModel>().Find(id);
            if (model == null)
                throw new FileNotFoundException();

            model.deleted = true;

            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

/*
        public async Task<PaginationEntity<TDocument>> PaginationBy(Expression<Func<TDocument, bool>> filterExpression, PaginationEntity<TDocument> pagination)
        {
            var sort = Builders<TDocument>.Sort.Ascending(pagination.Sort);
            if (pagination.SortDirection == "desc")
            {
                sort = Builders<TDocument>.Sort.Descending(pagination.Sort);
            }

            if (string.IsNullOrEmpty(pagination.Filter))
            {
                pagination.data = await _collection.Find(p => true)
                    .Sort(sort)
                    .Skip((pagination.page - 1) * pagination.pageSize)
                    .Limit(pagination.pageSize)
                    .ToListAsync();
            }
            else
            {
                pagination.data = await _collection.Find(filterExpression)
                    .Sort(sort)
                    .Skip((pagination.page - 1) * pagination.pageSize)
                    .Limit(pagination.pageSize)
                    .ToListAsync();
            }

            var totalDocuments = await _collection.CountDocumentsAsync(FilterDefinition<TDocument>.Empty);
            var totalPages = Convert.ToInt32(totalDocuments / pagination.pageSize);
            pagination.pageQuantity = totalPages;

            return pagination;
        }

        public async Task<PaginationEntity<TDocument>> PaginationByFilter(PaginationEntity<TDocument> pagination)
        {
            var sort = Builders<TDocument>.Sort.Ascending(pagination.Sort);
            if (pagination.SortDirection == "desc")
            {
                sort = Builders<TDocument>.Sort.Descending(pagination.Sort);
            }

            if (pagination.filterValue == null)
            {
                pagination.data = await _collection.Find(p => true)
                    .Sort(sort)
                    .Skip((pagination.page - 1) * pagination.pageSize)
                    .Limit(pagination.pageSize)
                    .ToListAsync();
            }
            else
            {
                var valueFilter = ".*" + pagination.filterValue.valor + ".*";
                var filter = Builders<TDocument>.Filter.Regex(pagination.filterValue.propiedad, new BsonRegularExpression(valueFilter, "i"));

                pagination.data = await _collection.Find(filter)
                    .Sort(sort)
                    .Skip((pagination.page - 1) * pagination.pageSize)
                    .Limit(pagination.pageSize)
                    .ToListAsync();
            }

            var totalDocuments = pagination.data.Count();
            var rounded = Math.Ceiling(totalDocuments / Convert.ToDecimal(pagination.pageSize));
            var totalPages = Convert.ToInt32(rounded);
            var totalRow = totalDocuments;
            pagination.pageQuantity = totalPages;
            pagination.totalRow = totalRow;

            return pagination;
    }
    */
    }
}

