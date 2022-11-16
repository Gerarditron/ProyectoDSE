using System;
using System.Collections.Generic;

namespace MVC_DSE.Models;

public partial class TipoCliente
{
    public int IdTipoCliente { get; set; }

    public string? TipoCliente1 { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();
}
