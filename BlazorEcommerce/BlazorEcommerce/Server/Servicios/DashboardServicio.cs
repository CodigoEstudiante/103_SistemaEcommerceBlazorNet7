using BlazorEcommerce.Server.Repositorios;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Servicios
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly IVentaRepositorio ventaRepositorio;
        private readonly IGenericoRepositorio<Persona> personaRepositorio;
        private readonly IGenericoRepositorio<Producto> productoRepositorio;
        public DashboardServicio(IVentaRepositorio ventaRepositorio, IGenericoRepositorio<Persona> personaRepositorio, IGenericoRepositorio<Producto> productoRepositorio)
        {
            this.ventaRepositorio = ventaRepositorio;
            this.personaRepositorio = personaRepositorio;

            this.productoRepositorio = productoRepositorio;

        }

        private string Ingresos()
        {
            var consulta =  ventaRepositorio.Consultar();
            decimal? ingresos = consulta.Sum(x => x.Total);
            return Convert.ToString(ingresos)!;
        }
        private int Ventas()
        {
            var consulta = ventaRepositorio.Consultar();
            int total = consulta.Count();
            return total!;
        }

        private int Clientes()
        {
            var consulta = personaRepositorio.Consultar();
            int total = consulta.Count();
            return total!;
        }
        private int Productos()
        {
            var consulta = productoRepositorio.Consultar();
            int total = consulta.Count();
            return total!;
        }


        public ResponseDTO<DashBoardDTO> Resumen()
        {
            ResponseDTO<DashBoardDTO> response = new ResponseDTO<DashBoardDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };
            try
            {
                DashBoardDTO dto = new DashBoardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalVentas = Ventas(),
                    TotalClientes = Clientes(),
                    TotalProductos = Productos()
                };
                response.Resultado = dto;
            }
            catch(Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = null;
            }
       
            return response;
        }
    }
}
