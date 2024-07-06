using EjemploEntity.Models;

namespace EjemploEntity.DTOs
{
    public class ProductoDTO
    {
            public double ProductoId { get; set; }

            public string? ProductoDescrip { get; set; }

            public string? Estado { get; set; }

            public DateTime? FechaHoraReg { get; set; }

            public double? Precio { get; set; }

            public string? CategNombre { get; set; }

            public string? MarcaNombre { get; set; }

            public string? ModeloDescripción { get; set; }
    }

}
