using System;
using System.Collections.Generic;

#nullable disable

namespace crud.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Ciudadanos = new HashSet<Ciudadano>();
        }

        public string Id { get; set; }
        public string Usuario1 { get; set; }
        public string Clave { get; set; }
        public string CorreoElectronico { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Ciudadano> Ciudadanos { get; set; }
    }
}
