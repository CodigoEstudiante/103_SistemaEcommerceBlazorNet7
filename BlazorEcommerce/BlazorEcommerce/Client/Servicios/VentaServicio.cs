using BlazorEcommerce.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Servicios
{
    public class VentaServicio : IVentaServicio
    {
        private readonly HttpClient _httpClient;
        public VentaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Venta/Registrar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
            return result!;
        }
    }
}
