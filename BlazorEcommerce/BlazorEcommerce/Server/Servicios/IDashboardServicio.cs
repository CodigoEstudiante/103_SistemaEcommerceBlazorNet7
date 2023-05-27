using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Servicios
{
    public interface IDashboardServicio
    {
        ResponseDTO<DashBoardDTO> Resumen();
    }
}
