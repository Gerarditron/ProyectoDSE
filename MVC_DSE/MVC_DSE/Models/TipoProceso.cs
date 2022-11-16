using System;
using System.Collections.Generic;

namespace MVC_DSE.Models;

public partial class TipoProceso
{
    public int IdTipoProceso { get; set; }

    public string? TipoProceso1 { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();
}
