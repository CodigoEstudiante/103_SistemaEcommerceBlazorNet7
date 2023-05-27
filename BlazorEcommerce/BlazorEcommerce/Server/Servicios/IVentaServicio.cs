using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Servicios
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
