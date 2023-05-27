using BlazorEcommerce.Shared;
using System.Drawing;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly HttpClient _httpClient;
        public ProductoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"/api/Producto/Catalogo/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Producto/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(ProductoDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Producto/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"/api/Producto/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Lista(string Valor)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"/api/Producto/Lista/{Valor}");
        }


        public async Task<ResponseDTO<ProductoDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductoDTO>>($"/api/Producto/Obtener/{Id}");
        }
    }
}
