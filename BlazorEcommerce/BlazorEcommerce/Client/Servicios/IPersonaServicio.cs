using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Servicios
{
    public interface IPersonaServicio
    {
        Task<ResponseDTO<List<PersonaDTO>>> Lista(string Rol,string Valor);
        Task<ResponseDTO<PersonaDTO>> Obtener(int Id);
        Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);
        Task<ResponseDTO<PersonaDTO>> Crear(PersonaDTO modelo);
        Task<ResponseDTO<bool>> Editar(PersonaDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);
    }
}
