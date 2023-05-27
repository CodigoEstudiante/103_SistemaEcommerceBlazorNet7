using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Servicios
{
    public interface IProductoServicio
    {
        Task<ResponseDTO<List<ProductoDTO>>> Lista(string Valor);
        Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar);
        Task<ResponseDTO<ProductoDTO>> Obtener(int id);
        Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo);
        Task<ResponseDTO<bool>> Editar(ProductoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
