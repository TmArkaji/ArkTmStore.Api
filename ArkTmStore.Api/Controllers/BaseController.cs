using ArkTmStore.Api.Models;
using ArkTmStore.Api.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArkTmStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public abstract class BaseController<TKey, TModel, TRepository> : ControllerBase
        where TModel : BaseModel<TKey>
        where TRepository : IBaseRepository<TKey, TModel>
    {

        private readonly IBaseRepository<TKey, TModel> _baseRepository;

        public BaseController(IBaseRepository<TKey, TModel> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TModel>>> Get()
        {
            return Ok(await _baseRepository.GetAll());
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TModel>> Get(TKey id)
        {
            return Ok(await _baseRepository.GetById(id));
        }

        [HttpPost]
        public virtual async Task Post(TModel model)
        {
            await _baseRepository.Insert(model);
        }

        [HttpPut("{id}")]
        public virtual async Task Put(TKey id, TModel model)
        {
            model.id = id;
            await _baseRepository.Update(model);
        }

        [HttpDelete("{id}")]
        public virtual async Task Delete(TKey id)
        {
            await _baseRepository.DeleteById(id);
        }

    }
}

