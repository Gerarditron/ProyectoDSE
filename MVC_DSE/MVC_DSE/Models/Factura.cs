using System;
using System.Collections.Generic;

namespace MVC_DSE.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int? IdTipoProceso { get; set; }

    public int? IdBitacora { get; set; }

    public string? Concepto { get; set; }

    public DateTime? FechaFactura { get; set; }

    public decimal? Valor { get; set; }

    public virtual Bitacora? IdBitacoraNavigation { get; set; }

    public virtual TipoProceso? IdTipoProcesoNavigation { get; set; }
}
