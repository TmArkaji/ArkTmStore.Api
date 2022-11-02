using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArkTmStore.Api.Models;
using ArkTmStore.Api.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArkTmStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : BaseController<int, Product, IProductoRepository>
    {
        public ProductoController(IProductoRepository baseRepository) : base(baseRepository)
        {
        }

        [HttpGet("Hola")]
        public string Hola()
        {
            return "Hola";
        }
    }
}

