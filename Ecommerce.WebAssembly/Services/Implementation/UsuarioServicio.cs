using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly HttpClient _httpClient;

        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        

        public async Task<ResponseDTO<UsuarioDTO>> Crear(LoginDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("UsuarioCrear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(LoginDTO modelo)
        {
            var response = await _httpClient.PatchAsJsonAsync("UsuarioEditar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return  await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>(($"Usuario/Eliminar/{id}"));
        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>(($"Usuario/Lista/{rol}/{buscar}"));
        }

        public  async Task<ResponseDTO<UsuarioDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>(($"Usuario/Obtener/{id}"));
        }
    }
}

