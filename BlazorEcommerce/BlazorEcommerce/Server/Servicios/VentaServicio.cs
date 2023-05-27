using BlazorEcommerce.Server.Repositorios;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Servicios
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IVentaRepositorio _ventaRepositorio;
        private readonly IMapper _mapper;
        public VentaServicio(IVentaRepositorio ventaRepositorio, IMapper mapper)
        {
            _ventaRepositorio =  ventaRepositorio;
            _mapper = mapper;

        }

        public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo)
        {
            ResponseDTO<VentaDTO> response = new ResponseDTO<VentaDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };
            try
            {
                var ventaGenerada = await _ventaRepositorio.Registrar(_mapper.Map<Venta>(modelo));

                if (ventaGenerada.IdVenta == 0)
                    throw new TaskCanceledException("No se pudo crear");

                response.Resultado = _mapper.Map<VentaDTO>(ventaGenerada);

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
