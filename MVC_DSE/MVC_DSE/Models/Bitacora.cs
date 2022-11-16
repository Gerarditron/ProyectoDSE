using System;
using System.Collections.Generic;

namespace MVC_DSE.Models;

public partial class Bitacora
{
    public int IdBitacora { get; set; }

    public int? IdCliente { get; set; }

    public string? Descripcion { get; set; }

    public string? NumReferencia { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaVerificada { get; set; }

    public TimeSpan? HoraVerificada { get; set; }

    public decimal? MontoTotal { get; set; }

    public int? Completada { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
