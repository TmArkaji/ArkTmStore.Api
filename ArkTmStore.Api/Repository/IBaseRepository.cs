using ArkTmStore.Api.Models;

namespace ArkTmStore.Api.Repository
{
    public interface IBaseRepository<TKey, TModel> where TModel : IBaseModel<TKey>
    {
        public Task<IEnumerable<TModel>> GetAll();
        public Task<TModel> GetById(TKey id);
        public Task Insert(TModel document);
        public Task Update(TModel document);
        public Task DeleteById(TKey id);
    }
}