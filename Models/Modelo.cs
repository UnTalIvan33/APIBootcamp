using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class Modelo
{
    public double? ModeloId { get; set; }

    public string? ModeloDescripción { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }
}
