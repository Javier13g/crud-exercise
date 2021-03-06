using System;
using System.Collections.Generic;

#nullable disable

namespace crud.Models
{
    public partial class Sector
    {
        public int Id { get; set; }
        public int MunicipioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Municipio Municipio { get; set; }
    }
}
