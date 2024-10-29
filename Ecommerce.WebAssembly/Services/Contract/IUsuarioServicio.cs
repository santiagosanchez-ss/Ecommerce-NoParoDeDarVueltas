using Ecommerce.DTO;


namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface IUsuarioServicio
    {

        Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar);
        Task<ResponseDTO<UsuarioDTO>> Obtener(int id);
        Task<ResponseDTO<UsuarioDTO>> Crear(LoginDTO modelo);
        Task<ResponseDTO<bool>> Editar(LoginDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
       
    }
}
