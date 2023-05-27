using BlazorEcommerce.Server.Repositorios;
using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BlazorEcommerce.Server.Servicios.PersonaSV
{
    public class PersonaServicio : IPersonaServicio
    {
        private readonly IGenericoRepositorio<Persona> _personaRepositorio;
        private readonly IMapper _mapper;
        public PersonaServicio(IGenericoRepositorio<Persona> personaRepositorio, IMapper mapper)
        {
            _personaRepositorio = personaRepositorio;
            _mapper = mapper;

        }
        public async Task<ResponseDTO<PersonaDTO>> Obtener(int id)
        {

            ResponseDTO<PersonaDTO> response = new ResponseDTO<PersonaDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _personaRepositorio.Consultar(p => p.IdPersona == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    response.Resultado = _mapper.Map<PersonaDTO>(fromDbModelo);
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se encontraron coincidencias";
                }

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = null;
            }
            return response;
        }
        public async Task<ResponseDTO<List<PersonaDTO>>> Lista(string Rol, string Valor)
        {
            ResponseDTO<List<PersonaDTO>> response = new ResponseDTO<List<PersonaDTO>>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _personaRepositorio.Consultar(p =>
                    p.Rol == Rol &&
                    string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(Valor.ToLower())
                );

                List<PersonaDTO> lista = _mapper.Map<List<PersonaDTO>>(await consulta.ToListAsync());
                response.Resultado = lista;
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = null;
            }
            return response;
        }

        public async Task<ResponseDTO<PersonaDTO>> Crear(PersonaDTO modelo)
        {
            ResponseDTO<PersonaDTO> response = new ResponseDTO<PersonaDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var dbModelo = _mapper.Map<Persona>(modelo);
                var rspModelo = await _personaRepositorio.Crear(dbModelo);

                if (rspModelo.IdPersona != 0)
                    response.Resultado = _mapper.Map<PersonaDTO>(rspModelo);
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se pudo crear";
                }

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = null;
            }

            return response;

        }

        public async Task<ResponseDTO<bool>> Editar(PersonaDTO modelo)
        {
            ResponseDTO<bool> response = new ResponseDTO<bool>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _personaRepositorio.Consultar(p => p.IdPersona == modelo.IdPersona);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.NombreCompleto = modelo.NombreCompleto;
                    fromDbModelo.Correo = modelo.Correo;
                    fromDbModelo.Clave = modelo.Clave;

                    var respuesta = await _personaRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                    {
                        response.EsCorrecto = false;
                        response.Mensaje = "No se pudo editar";
                    }
                }
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se encontraron resultados";
                }

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = false;
            }

            return response;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            ResponseDTO<bool> response = new ResponseDTO<bool>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _personaRepositorio.Consultar(p => p.IdPersona == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _personaRepositorio.Eliminar(fromDbModelo);

                    if (!respuesta)
                    {
                        response.EsCorrecto = false;
                        response.Mensaje = "No se pudo eliminar";
                    }
                }
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se encontraron resultados";
                }

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = false;
            }

            return response;
        }

        public async Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
        {
            ResponseDTO<SesionDTO> response = new ResponseDTO<SesionDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _personaRepositorio.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    response.Resultado = _mapper.Map<SesionDTO>(fromDbModelo);
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se encontraron coincidencias";
                }

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = null;
            }
            return response;
        }
    }
}
