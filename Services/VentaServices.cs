using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilities;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class VentaServices : IVenta
    {
        private readonly PracticaVentasContext _context;
        private ControlError Log = new ControlError();

        public VentaServices(PracticaVentasContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetVenta(string? NumFact)
        {
            var respuesta = new Respuesta();
            try
            {
                if (NumFact == null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join m in _context.Marcas on v.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on v.CategId equals c.CategId
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join p in _context.Productos on v.ProductoId equals p.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join s in _context.Sucursals on v.SucursalId equals s.SucursalId
                                            where v.Estado.Equals("A")
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteNombre = cl.ClienteNombre,
                                                ProductoDescrip = p.ProductoDescrip,
                                                ModeloDescripción = mo.ModeloDescripción,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                SucursalNombre = s.SucursalNombre,
                                                Caja = v.Caja,
                                                Vendedor = v.Vendedor,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado,
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (NumFact != null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join m in _context.Marcas on v.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on v.CategId equals c.CategId
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join p in _context.Productos on v.ProductoId equals p.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join s in _context.Sucursals on v.SucursalId equals s.SucursalId
                                            where v.Estado.Equals("A") & v.NumFact.Equals(NumFact)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteNombre = cl.ClienteNombre,
                                                ProductoDescrip = p.ProductoDescrip,
                                                ModeloDescripción = mo.ModeloDescripción,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                SucursalNombre = s.SucursalNombre,
                                                Caja = v.Caja,
                                                Vendedor = v.Vendedor,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado,
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices","GetVenta", ex.Message);
            }
            return respuesta;
        }
    }

}