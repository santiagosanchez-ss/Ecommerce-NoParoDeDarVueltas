using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contract;
using System.Net.Http;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class VentaServicio : IVentaServicio
    {
        public readonly HttpClient _httpClient;

        public VentaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo)
        {

            var response = await _httpClient.PostAsJsonAsync("VentaRegistrar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
            return result!;
        }
    }
}
