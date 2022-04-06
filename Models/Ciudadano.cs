using System;
using System.Collections.Generic;

#nullable disable

namespace crud.Models
{
    public partial class Ciudadano
    {
        public string Id { get; set; }
        public int Secuencia { get; set; }
        public string NoCedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int? OcupacionId { get; set; }
        public int? TipoDeSangreId { get; set; }
        public string Sexo { get; set; }
        public int? LugarDeNacimientoId { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public DateTime? FechaDeExpiracion { get; set; }
        public int? NacionalidadId { get; set; }
        public int? EstadoCivilId { get; set; }
        public string Firma { get; set; }
        public int? ColegioElectoralId { get; set; }
        public string Foto { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string RegistroDeNacimiento { get; set; }
        public int? EstadoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacionId { get; set; }

        public virtual ColegioElectoral ColegioElectoral { get; set; }
        public virtual CiudadanoEstado Estado { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual Provincium LugarDeNacimiento { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
        public virtual Ocupacion Ocupacion { get; set; }
        public virtual TipoDeSangre TipoDeSangre { get; set; }
        public virtual Usuario UsuarioCreacion { get; set; }
    }
}
