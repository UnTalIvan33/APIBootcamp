using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface IProducto
    {
        Task<Respuesta> GetListaProductos(int productoID, double precio);
        //Task<List<ProductoDTO>> GetListaProductosPrecios(double valor);
        Task<Respuesta> PostProducto(Producto producto);
        Task<Respuesta> PutProducto(Producto producto);
    }
}
