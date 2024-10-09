﻿using System;
using System.Collections.Generic;

namespace Cliente.Web.Api.Dominio.Persistencia.Modelos;

public partial class Indicativo
{
    public long IdIndicativo { get; set; }

    public string? Codigo { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
