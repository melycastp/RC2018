//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Seccione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seccione()
        {
            this.RCasillas = new HashSet<RCasilla>();
        }
    
        public string idSeccion { get; set; }
        public int seccion { get; set; }
        public string casilla { get; set; }
        public int distrito { get; set; }
        public int idMunicipio { get; set; }
        public int listaNominal { get; set; }
    
        public virtual Municipio Municipio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RCasilla> RCasillas { get; set; }
    }
}
