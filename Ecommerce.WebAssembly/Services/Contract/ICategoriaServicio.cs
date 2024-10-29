using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface ICategoriaServicio
    {

        Task<ResponseDTO<List<CategoriaDTO>>> Lista( string buscar);
        Task<ResponseDTO<CategoriaDTO>> Obtener(int id);
        Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);
        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);

    }
}
