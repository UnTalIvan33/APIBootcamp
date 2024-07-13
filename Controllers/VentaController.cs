using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VentaController : Controller
    {
        private readonly IVenta _venta;
        private ControlError Log = new ControlError();

        public VentaController(IVenta venta)
        {
            this._venta = venta;
        }


        [HttpGet]
        [Route("GetVenta")]
        public async Task<Respuesta> GetVenta(string? NumFact)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVenta(NumFact);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentaController", "GetVenta", ex.Message);
            }
            return respuesta;
        }
    }
}
