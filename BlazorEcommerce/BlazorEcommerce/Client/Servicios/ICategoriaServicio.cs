using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Servicios
{
    public interface ICategoriaServicio
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista(string Valor);
        Task<ResponseDTO<CategoriaDTO>> Obtener(int Id);
        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);
    }
}
