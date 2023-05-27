using BlazorEcommerce.Server.Servicios.PersonaSV;
using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaServicio _personaServicio;
        public PersonaController(IPersonaServicio personaServicio)
        {
            _personaServicio = personaServicio;
        }

        [HttpGet("Lista/{Rol:alpha}/{Valor:alpha?}")]
        public async Task<IActionResult> Lista(string Rol, string Valor = "NA")
        {
            if (Valor == "NA") Valor = "";
            return Ok(await _personaServicio.Lista(Rol, Valor));
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            return Ok(await _personaServicio.Obtener(Id));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] PersonaDTO modelo)
        {
            return Ok(await _personaServicio.Crear(modelo));
        }

        [HttpPost("Autorizacion")]
        public async Task<IActionResult> Autorizacion([FromBody]LoginDTO modelo)
        {
            return Ok(await _personaServicio.Autorizacion(modelo));
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] PersonaDTO modelo)
        {
            return Ok(await _personaServicio.Editar(modelo));
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            return Ok(await _personaServicio.Eliminar(Id));
        }



    }
}
