using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class CatalogoServices : ICatalogo
    {
		private readonly PracticaVentasContext _context;

		public CatalogoServices(PracticaVentasContext context)
		{ 
			this._context = context;
		}

        public async Task<Respuesta> GetCategoria()
        {
			var respuesta = new Respuesta();
			try
			{
				respuesta.Cod = "000";
				respuesta.Data = await _context.Categoria.ToListAsync();
				respuesta.Mensaje = "OK";
			}
			catch (Exception ex)
			{
				respuesta.Cod = "999";
                respuesta.Mensaje = $"Se ha presentado una novedad en el Metodo: GetCategoria, Error: {ex.Message}";
			}
			return respuesta;
        }
        public async Task<Respuesta> GetMarca()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Marcas.ToListAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se ha presentado una novedad en el Metodo: GetMarca, Error: {ex.Message}";
            }
            return respuesta;
        }
        public async Task<Respuesta> GetSucursal()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Sucursals.ToListAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se ha presentado una novedad en el Metodo: GetSucursal, Error: {ex.Message}";
            }
            return respuesta;
        }
        public async Task<Respuesta> GetModelo()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Modelos.ToListAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se ha presentado una novedad en el Metodo: GetModelo, Error: {ex.Message}";
            }
            return respuesta;
        }
    }
}
