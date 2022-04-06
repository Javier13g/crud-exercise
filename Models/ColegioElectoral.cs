using System;
using System.Collections.Generic;

#nullable disable

namespace crud.Models
{
    public partial class ColegioElectoral
    {
        public ColegioElectoral()
        {
            Ciudadanos = new HashSet<Ciudadano>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string MunicipioId { get; set; }
        public string SectorId { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Ciudadano> Ciudadanos { get; set; }
    }
}
