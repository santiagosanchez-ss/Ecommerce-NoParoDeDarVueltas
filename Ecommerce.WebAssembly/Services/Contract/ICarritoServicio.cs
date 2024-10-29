using Ecommerce.DTO;


namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface ICarritoServicio
    {
        event Action MostrarItems;
        
        Task AgregarCarrito(CarritoDTO modelo);
        int CantidadProductos();
        Task EliminarCarrito(int idProducto);
        Task<List<CarritoDTO>> DevolverCarrito();
        Task LimpiarCarrito();
    }
}
