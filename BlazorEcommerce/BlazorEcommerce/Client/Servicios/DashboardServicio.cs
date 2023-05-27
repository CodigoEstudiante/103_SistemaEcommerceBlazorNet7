using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Servicios
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly HttpClient _httpClient;
        public DashboardServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<DashBoardDTO>> Resumen()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashBoardDTO>>($"/api/Dashboard/Resumen");
        }
    }
}
