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
    
    public partial class RCasilla
    {
        public string idRegistroCasilla { get; set; }
        public string idUsuario { get; set; }
        public string idSeccion { get; set; }
        public string tipoEleccion { get; set; }
        public System.DateTime fecha { get; set; }
        public int PAN { get; set; }
        public int PRI { get; set; }
        public int PRD { get; set; }
        public int PT { get; set; }
        public int PVEM { get; set; }
        public int MC { get; set; }
        public int PANAL { get; set; }
        public int MORENA { get; set; }
        public int ENSOC { get; set; }
        public int PPG { get; set; }
        public int PIH { get; set; }
        public int PCG { get; set; }
        public int PSM { get; set; }
        public int PSG { get; set; }
        public int CANDIND { get; set; }
        public int CANDNOREG { get; set; }
        public int VALIDOS { get; set; }
        public int NULOS { get; set; }
        public decimal PCIUD { get; set; }
        public int Total { get; set; }
        public bool Editable { get; set; }
        public string status { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual Seccione Seccione { get; set; }
    }
}
