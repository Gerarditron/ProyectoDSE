using System;
using System.Collections.Generic;

namespace MVC_DSE.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int? IdTipoCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? ApellidoCliente { get; set; }

    public int? Activo { get; set; }

    public virtual ICollection<Bitacora> Bitacoras { get; } = new List<Bitacora>();

    public virtual TipoCliente? IdTipoClienteNavigation { get; set; }
}
