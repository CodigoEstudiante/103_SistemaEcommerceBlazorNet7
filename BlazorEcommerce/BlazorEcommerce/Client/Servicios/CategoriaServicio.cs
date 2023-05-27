using BlazorEcommerce.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Servicios
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly HttpClient _httpClient;
        public CategoriaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Categoria/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Categoria/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"/api/Categoria/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista(string Valor)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"/api/Categoria/Lista/{Valor}");
        }

        public async Task<ResponseDTO<CategoriaDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"/api/Categoria/Obtener/{Id}");
        }
    }
}
