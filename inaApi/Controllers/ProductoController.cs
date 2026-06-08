using inaApp.Common.Interfaces;
using inaApp.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace inaApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericService<Producto> _productoService;

        public ProductoController(IGenericService<Producto> productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var productos = await _productoService.obtenerTodosAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            return Ok($"Detalle producto {id}");
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Producto producto)
        {
            try
            {
                var result = await _productoService.CrearAsync(producto);
                return Created("Producto Creado",result);
            }
            catch (Exception)
            {

                return BadRequest("Erro al crar el producto");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] Producto producto)
        {
            return Ok($"Producto {id} editado");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Error al eliminar, id Icorrecto");
            }

            var result = await _productoService.EliminarAsync(id);

            return result ? Ok("Producto Eliminado") : BadRequest("Erro al eliminar el producot");

        }
    }
}