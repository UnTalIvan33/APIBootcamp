using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class ProductoServices : IProducto
    {
		private readonly PracticaVentasContext _context;

        public ProductoServices(PracticaVentasContext context)
		{
			this._context = context;
		}
		public async  Task<Respuesta> GetListaProductos(int productoID, double precio)
        {
			var respuesta = new Respuesta();
			try
			{
                if (productoID == 0 && precio == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.Estado.Equals("A")
                                            select new ProductoDTO
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.Estado,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloDescripción = mo.ModeloDescripción
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (productoID != 0 && precio == 0)
                {
                    //respuesta.Data = await _context.Productos.Where(x => x.ProductoId.Equals(productoID)).ToListAsync();
                    respuesta.Cod = "000";
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where (p.Estado.Equals("A") && p.ProductoId.Equals(productoID))
                                            select new ProductoDTO
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.Estado,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloDescripción = mo.ModeloDescripción
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (productoID != 0 && precio != 0)
                {
                    //respuesta.Data = await _context.Productos.Where(x => x.ProductoId.Equals(productoID)).ToListAsync();
                    respuesta.Cod = "000";
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where (p.Estado.Equals("A") && p.ProductoId.Equals(productoID) && p.Precio.Equals(precio))
                                            select new ProductoDTO
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.Estado,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloDescripción = mo.ModeloDescripción
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                }
			catch (Exception)
			{

				throw;
			}
			return respuesta;
        }
        /*public async Task<List<ProductoDTO>> GetListaProductosPrecios(double valor)
        {
            var respuesta = new List<ProductoDTO>();
            try
            {
                if (valor == 0)
                {
                    respuesta = await _context.Productos.ToListAsync();
                }
                else
                {
                    respuesta = await _context.Productos.Where(x => x.Precio == valor).ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }*/
        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Productos.OrderByDescending(x => x.ProductoId).Select(x => x.ProductoId).FirstOrDefault();
                producto.ProductoId = Convert.ToInt32(query) + 1;
                producto.FechaHoraReg = DateTime.Now;

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<Respuesta> PutProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            bool valida = false;
            try
            {
                valida = await _context.Categoria.Where(x => x.CategId.Equals(producto.CategId)).AnyAsync();

                if (valida)
                {
                    _context.Productos.Update(producto);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizo correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = $"No existe categoria";
                }
                
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
            }
            return respuesta;
        }
    }
}
