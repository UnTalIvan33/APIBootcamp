namespace EjemploEntity.DTOs
{
    public class VentaDTO
    {
        public double IdFactura { get; set; }

        public string? NumFact { get; set; }

        public DateTime? FechaHora { get; set; }

        public string? ClienteNombre { get; set; }

        public string? ProductoDescrip { get; set; }

        public string? ModeloDescripción { get; set; }

        public string? CategNombre { get; set; }

        public string? MarcaNombre { get; set; }

        public string? SucursalNombre { get; set; }

        public string? Caja { get; set; }

        public string? Vendedor { get; set; }

        public double? Precio { get; set; }

        public double? Unidades { get; set; }

        public string? Estado { get; set; }
    }
}
