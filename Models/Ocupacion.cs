using System;
using System.Collections.Generic;

#nullable disable

namespace crud.Models
{
    public partial class Ocupacion
    {
        public Ocupacion()
        {
            Ciudadanos = new HashSet<Ciudadano>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Ciudadano> Ciudadanos { get; set; }
    }
}
