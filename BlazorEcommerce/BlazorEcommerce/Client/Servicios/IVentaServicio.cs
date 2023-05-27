using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Servicios
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
