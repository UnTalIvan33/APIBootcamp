﻿using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : Controller
    {
        private readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            this._cliente = cliente;
        }


        [HttpGet]
        [Route("GetCliente")]
        public async Task<Respuesta> GetCliente(int ClienteId, string? ClienteNombre, double Cedula)
        {
        var respuesta = new Respuesta();
            try
            {
            respuesta = await _cliente.GetCliente(ClienteId, ClienteNombre, Cedula);
            }
            catch (Exception)
            {
                
                throw;
            }
        return respuesta;
        }
        [HttpPost]
        [Route("PostCliente")]
        public async Task<Respuesta> PostCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.PostCliente(cliente);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

    }
}
