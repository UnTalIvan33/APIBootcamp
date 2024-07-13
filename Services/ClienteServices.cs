using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EjemploEntity.Services
{
    public class ClienteServices : ICliente
    {
        private readonly PracticaVentasContext _context;

        public ClienteServices(PracticaVentasContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> GetCliente(int ClienteId, string? ClienteNombre, double Cedula)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Clientes;

                if (ClienteId == 0 && ClienteNombre == null && Cedula == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("A")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if(ClienteId != 0 && ClienteNombre == null && Cedula == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("A") && x.ClienteId.Equals(ClienteId)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (ClienteId == 0 && ClienteNombre != null && Cedula == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("A") && x.ClienteNombre.Equals(ClienteNombre)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (ClienteId == 0 && ClienteNombre == null && Cedula != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("A") && x.Cedula.Equals(Cedula)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (ClienteId != 0 && ClienteNombre != null && Cedula != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("A") && x.ClienteId.Equals(ClienteId) && x.ClienteNombre.Equals(ClienteNombre) && x.Cedula.Equals(Cedula)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se ha presentado una novedad en el Metodo: GetCliente, Error: {ex.Message}";
            }
            return respuesta;
        }

        public Task<Respuesta> PostCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
