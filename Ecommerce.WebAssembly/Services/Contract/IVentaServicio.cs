using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
