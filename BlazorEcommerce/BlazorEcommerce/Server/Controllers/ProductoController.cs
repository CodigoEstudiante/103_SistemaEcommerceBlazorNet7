using BlazorEcommerce.Server.Servicios;
using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoServicio _productoServicio;
        public ProductoController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet("Lista/{Valor:alpha?}")]
        public async Task<IActionResult> Lista(string Valor = "NA")
        {
            if (Valor == "NA") Valor = "";
            return Ok(await _productoServicio.Lista(Valor));
        }

        [HttpGet("Catalogo/{categoria:alpha}/{buscar:alpha?}")]
        public async Task<IActionResult> Catalogo(string categoria, string buscar = "NA")
        {
            if (categoria.ToLower() == "todos") categoria = "";
            if (buscar == "NA") buscar = "";
            return Ok(await _productoServicio.Catalogo(categoria, buscar));
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            return Ok(await _productoServicio.Obtener(Id));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO modelo)
        {
            return Ok(await _productoServicio.Crear(modelo));
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO modelo)
        {
            return Ok(await _productoServicio.Editar(modelo));
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            return Ok(await _productoServicio.Eliminar(Id));
        }
    }
}
