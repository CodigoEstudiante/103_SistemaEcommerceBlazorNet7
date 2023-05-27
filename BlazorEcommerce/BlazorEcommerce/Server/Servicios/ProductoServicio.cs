using BlazorEcommerce.Server.Repositorios;
using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BlazorEcommerce.Server.Servicios
{
    public class ProductoServicio : IProductoServicio
    {

        private readonly IGenericoRepositorio<Producto> _productoRepositorio;
        private readonly IMapper _mapper;
        public ProductoServicio(IGenericoRepositorio<Producto> productoRepositorio, IMapper mapper)
        {
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;

        }
        public async Task<ResponseDTO<List<ProductoDTO>>> Lista(string Valor)
        {
            ResponseDTO<List<ProductoDTO>> response = new ResponseDTO<List<ProductoDTO>>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _productoRepositorio
                    .Consultar(c =>
                    c.Nombre!.ToLower().Contains(Valor.ToLower())
                );

                consulta = consulta.Include(c => c.IdCategoriaNavigation);

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
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
        public async Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar)
        {

            ResponseDTO<List<ProductoDTO>> response = new ResponseDTO<List<ProductoDTO>>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _productoRepositorio
                .Consultar(c =>
                    c.Nombre!.ToLower().Contains(buscar.ToLower()) &&
                    c.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower())
                );

                consulta = consulta.Include(c => c.IdCategoriaNavigation);

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
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
        public async Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo)
        {
            ResponseDTO<ProductoDTO> response = new ResponseDTO<ProductoDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var dbModelo = _mapper.Map<Producto>(modelo);
                var rspModelo = await _productoRepositorio.Crear(dbModelo);

                if (rspModelo.IdProducto != 0)
                    response.Resultado = _mapper.Map<ProductoDTO>(rspModelo);
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
        public async Task<ResponseDTO<ProductoDTO>> Obtener(int id)
        {
            ResponseDTO<ProductoDTO> response = new ResponseDTO<ProductoDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _productoRepositorio.Consultar(p => p.IdProducto == id);
                consulta = consulta.Include(c => c.IdCategoriaNavigation);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    response.Resultado = _mapper.Map<ProductoDTO>(fromDbModelo);
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

        public async Task<ResponseDTO<bool>> Editar(ProductoDTO modelo)
        {

            ResponseDTO<bool> response = new ResponseDTO<bool>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _productoRepositorio.Consultar(p => p.IdProducto == modelo.IdProducto);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.IdCategoria = modelo.IdCategoria;
                    fromDbModelo.Precio = modelo.Precio;
                    fromDbModelo.PrecioOferta = modelo.PrecioOferta;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Imagen = modelo.Imagen;

                    var respuesta = await _productoRepositorio.Editar(fromDbModelo);

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
                var consulta = _productoRepositorio.Consultar(p => p.IdProducto == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _productoRepositorio.Eliminar(fromDbModelo);

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
