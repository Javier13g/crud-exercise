using System;
using System.Collections.Generic;

#nullable disable

namespace crud.Models
{
    public partial class Provincium
    {
        public Provincium()
        {
            Ciudadanos = new HashSet<Ciudadano>();
            Municipios = new HashSet<Municipio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Ciudadano> Ciudadanos { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
