using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashBoardDTO>> Resumen();
    }
}
