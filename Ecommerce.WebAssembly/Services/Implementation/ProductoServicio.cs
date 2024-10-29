using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contract;
using System.Net.Http;
using System.Net.Http.Json;



namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class ProductoServicio : IProductoServicio
    {
        public readonly HttpClient _httpClient;

        public ProductoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async  Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>(($"Producto/Catalogo/{categoria}/{buscar}"));
        }
    

        public async Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo)
        {
        var response = await _httpClient.PostAsJsonAsync("ProductoCrear", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();
        return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(ProductoDTO modelo)
        {
            var response = await _httpClient.PatchAsJsonAsync("ProductoEditar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>(($"Usuario/Eliminar/{id}"));
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>(($"Producto/Lista/{buscar}"));
        }

        public async Task<ResponseDTO<ProductoDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductoDTO>>(($"Usuario/Obtener/{id}"));
        }

    }
}
