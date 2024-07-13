using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface IVenta
    {
        Task<Respuesta> GetVenta(string? NumFact);
    }
}
