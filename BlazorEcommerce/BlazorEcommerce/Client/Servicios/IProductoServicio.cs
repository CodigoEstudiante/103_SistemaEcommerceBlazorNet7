using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Servicios
{
    public interface IProductoServicio
    {
        Task<ResponseDTO<List<ProductoDTO>>> Lista(string Valor);
        Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar);
        Task<ResponseDTO<ProductoDTO>> Obtener(int Id);
        Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo);
        Task<ResponseDTO<bool>> Editar(ProductoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);
    }
}
