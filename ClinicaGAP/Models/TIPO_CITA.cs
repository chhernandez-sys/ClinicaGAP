//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicaGAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TIPO_CITA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_CITA()
        {
            this.CITA = new HashSet<CITA>();
        }
    
        public int ID_TIPO_CITA { get; set; }
        [StringLength(30, MinimumLength = 1, ErrorMessage = "La descripción no debe superar los 30 caracteres.")]
        public string DESCRIPCION { get; set; }
        public int ESTADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITA> CITA { get; set; }
        public virtual ESTADO ESTADO1 { get; set; }
    }
}