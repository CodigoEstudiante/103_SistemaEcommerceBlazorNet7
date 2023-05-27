using BlazorEcommerce.Server.Servicios;
using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServicio _categoriaServicio;
        public CategoriaController(ICategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }

        [HttpGet("Lista/{Valor:alpha?}")]
        public async Task<IActionResult> Lista(string Valor = "NA")
        {
            if (Valor == "NA") Valor = "";
            return Ok(await _categoriaServicio.Lista(Valor));
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            return Ok(await _categoriaServicio.Obtener(Id));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CategoriaDTO modelo)
        {
            return Ok(await _categoriaServicio.Crear(modelo));
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO modelo)
        {
            return Ok(await _categoriaServicio.Editar(modelo));
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            return Ok(await _categoriaServicio.Eliminar(Id));
        }

    }
}
