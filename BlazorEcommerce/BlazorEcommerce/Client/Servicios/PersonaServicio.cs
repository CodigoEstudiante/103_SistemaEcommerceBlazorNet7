using BlazorEcommerce.Shared;
using System.Net.Http.Json;
using System.Reflection;

namespace BlazorEcommerce.Client.Servicios
{
    public class PersonaServicio : IPersonaServicio
    {
        private readonly HttpClient _httpClient;
        public PersonaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<List<PersonaDTO>>> Lista(string Rol, string Valor)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<PersonaDTO>>>($"/api/Persona/Lista/{Rol}/{Valor}");
        }

        public async Task<ResponseDTO<PersonaDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<PersonaDTO>>($"/api/Persona/Obtener/{Id}");
        }

        public async Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Persona/Autorizacion", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();
            return result!;
        }
        public async Task<ResponseDTO<PersonaDTO>> Crear(PersonaDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Persona/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<PersonaDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(PersonaDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Persona/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"/api/Persona/Eliminar/{Id}");
        }

   
    }
}
