using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProducto _producto;

        public ProductoController(IProducto producto)
        {
            this._producto = producto;
        }

        [HttpGet]
        [Route("GetListaProductos")]
        public async Task<Respuesta> GetListaProductos(int productoID, double valor)
        {
            var respuesta = new Respuesta ();
            try
            {
                respuesta = await _producto.GetListaProductos(productoID, valor);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        //[HttpGet]
        //[Route("GetListaProductosPrecios")]
        //public async Task<List<ProductoDTO>> GetListaProductosPrecios(double valor)
        //{
        //    var respuesta = new List<ProductoDTO>();
        //    try
        //    {
        //        respuesta = await _producto.GetListaProductosPrecios(valor);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return respuesta;
        //}

        [HttpPost]
        [Route("PostProducto")]
        public async Task<Respuesta> PostProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PostProducto(producto);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutProducto")]
        public async Task<Respuesta> PutProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PutProducto(producto);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
