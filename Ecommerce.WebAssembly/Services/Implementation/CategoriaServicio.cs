using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contract;
using System.Net.Http;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class CategoriaServicio : ICategoriaServicio
    {
        public readonly HttpClient _httpClient;


        public CategoriaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo)
        {

            var response = await _httpClient.PostAsJsonAsync("CategoriaCrear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo)
        {
            var response = await _httpClient.PatchAsJsonAsync("CategoriaEditar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>(($"Usuario/Eliminar/{id}"));
        }

        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>(($"Usuario/Eliminar/{buscar}"));
        }

        public async Task<ResponseDTO<CategoriaDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>(($"Categoria/Obtener/{id}"));
        }
    }
}
