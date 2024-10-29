using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contract;
using System.Net.Http;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class DashboardServicio : IDashboardServicio
    {
        public readonly HttpClient _httpClient;


        public DashboardServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashBoardDTO>> Resumen()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashBoardDTO>>(($"Dashboard/Resumen"));
        }
    }
}
