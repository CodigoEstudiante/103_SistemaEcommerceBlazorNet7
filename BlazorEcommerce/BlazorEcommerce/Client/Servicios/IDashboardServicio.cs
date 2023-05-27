using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Servicios
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashBoardDTO>> Resumen();
    }
}
