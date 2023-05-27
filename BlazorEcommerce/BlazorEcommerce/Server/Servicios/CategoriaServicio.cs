using BlazorEcommerce.Server.Repositorios;
using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Servicios
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly IGenericoRepositorio<Categoria> _categoriaRepositorio;
        private readonly IMapper _mapper;
        public CategoriaServicio(IGenericoRepositorio<Categoria> categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;

        }
        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista(string Valor)
        {
            ResponseDTO<List<CategoriaDTO>> response = new ResponseDTO<List<CategoriaDTO>>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _categoriaRepositorio.Consultar(c =>
                    c.Nombre!.ToLower().Contains(Valor.ToLower())
                );

                List<CategoriaDTO> lista = _mapper.Map<List<CategoriaDTO>>(await consulta.ToListAsync());
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
        public async Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo)
        {
            ResponseDTO<CategoriaDTO> response = new ResponseDTO<CategoriaDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var dbModelo = _mapper.Map<Categoria>(modelo);
                var rspModelo = await _categoriaRepositorio.Crear(dbModelo);

                if (rspModelo.IdCategoria != 0)
                    response.Resultado = _mapper.Map<CategoriaDTO>(rspModelo);
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
        public async Task<ResponseDTO<CategoriaDTO>> Obtener(int id)
        {
            ResponseDTO<CategoriaDTO> response = new ResponseDTO<CategoriaDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _categoriaRepositorio.Consultar(p => p.IdCategoria == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    response.Resultado = _mapper.Map<CategoriaDTO>(fromDbModelo);
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

        public async Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo)
        {

            ResponseDTO<bool> response = new ResponseDTO<bool>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _categoriaRepositorio.Consultar(p => p.IdCategoria == modelo.IdCategoria);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;

                    var respuesta = await _categoriaRepositorio.Editar(fromDbModelo);

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
                var consulta = _categoriaRepositorio.Consultar(p => p.IdCategoria == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _categoriaRepositorio.Eliminar(fromDbModelo);

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




    }
}
