using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> GetCliente(int ClienteId, string? ClienteNombre, double Cedula);
        Task<Respuesta> PostCliente(Cliente cliente);
    }
}
