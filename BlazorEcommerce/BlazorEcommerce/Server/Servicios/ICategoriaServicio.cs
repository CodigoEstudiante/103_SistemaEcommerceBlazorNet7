using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Servicios
{
    public interface ICategoriaServicio
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista(string Valor);
        Task<ResponseDTO<CategoriaDTO>> Obtener(int id);
        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
