using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [MetadataType(typeof(VRCasilla))]
    public partial class RCasilla
    {
        public class VRCasilla
        {
            [Required(ErrorMessage = "El Usuario es requerido")]
            [DisplayName("Usuario")]
            public string idUsuario { get; set; }

            [Required(ErrorMessage = "La sección es requerido")]
            [DisplayName("Sección")]
            public string idSeccion { get; set; }

            [Required(ErrorMessage = "El tipo de elección es requerido")]
            [DisplayName("Tipo elección")]
            public string tipoEleccion { get; set; }

            [Required(ErrorMessage = "La Fecha es requerido")]
            [DisplayName("Fecha")]
            public System.DateTime fecha { get; set; }

            [Required(ErrorMessage = "La cifra del PAN es requerido")]
            [Range(0, 9999)]
            [DisplayName("PAN")]
            public int PAN { get; set; }

            [Required(ErrorMessage = "La cifra del PRI es requerido")]
            [Range(0, 9999)]
            [DisplayName("PRI")]
            public int PRI { get; set; }

            [Required(ErrorMessage = "La cifra del PRD es requerido")]
            [Range(0, 9999)]
            [DisplayName("PRD")]
            public int PRD { get; set; }

            [Required(ErrorMessage = "La cifra del PT es requerido")]
            [Range(0, 9999)]
            [DisplayName("PT")]
            public int PT { get; set; }

            [Required(ErrorMessage = "La cifra del PVEM es requerido")]
            [Range(0, 9999)]
            [DisplayName("PVEM")]
            public int PVEM { get; set; }

            [Required(ErrorMessage = "La cifra de Movimiento Ciudadano es requerido")]
            [Range(0, 9999)]
            [DisplayName("Movimiento Ciudadano")]
            public int MC { get; set; }

            [Required(ErrorMessage = "La cifra del PANAL es requerido")]
            [Range(0, 9999)]
            [DisplayName("PANAL")]
            public int PANAL { get; set; }

            [Required(ErrorMessage = "La cifra de MORENA es requerido")]
            [Range(0, 9999)]
            [DisplayName("MORENA")]
            public int MORENA { get; set; }

            [Required(ErrorMessage = "La cifra de Encuentro Social es requerido")]
            [Range(0, 9999)]
            [DisplayName("Encuentro Social")]
            public int ENSOC { get; set; }

            [Required(ErrorMessage = "La cifra del PPG es requerido")]
            [Range(0, 9999)]
            [DisplayName("PPG")]
            public int PPG { get; set; }

            [Required(ErrorMessage = "La cifra del PIH es requerido")]
            [Range(0, 9999)]
            [DisplayName("PIH")]
            public int PIH { get; set; }

            [Required(ErrorMessage = "La cifra del PCG es requerido")]
            [Range(0, 9999)]
            [DisplayName("PCG")]
            public int PCG { get; set; }

            [Required(ErrorMessage = "La cifra del PSM es requerido")]
            [Range(0, 9999)]
            [DisplayName("PSM")]
            public int PSM { get; set; }

            [Required(ErrorMessage = "La cifra del PSG es requerido")]
            [Range(0, 9999)]
            [DisplayName("PSG")]
            public int PSG { get; set; }

            [Required(ErrorMessage = "La cifra del INDEPENDIENTE es requerido")]
            [Range(0, 9999)]
            [DisplayName("INDEPENDIENTE")]
            public int CANDIND { get; set; }

            [Required(ErrorMessage = "La cifra del NO REGISTRADO es requerido")]
            [Range(0, 9999)]
            [DisplayName("NO REGISTRADO")]
            public int CANDNOREG { get; set; }

            [Required(ErrorMessage = "La cifra de VALIDOS es requerido")]
            [Range(0, 9999)]
            [DisplayName("VALIDOS")]
            public int VALIDOS { get; set; }

            [Required(ErrorMessage = "La cifra de NULOS es requerido")]
            [Range(0, 9999)]
            [DisplayName("NULOS")]
            public int NULOS { get; set; }

            [Required(ErrorMessage = "La cifra del PCIUD es requerido")]
            [DisplayName("PCIUD (%)")]
            public decimal PCIUD { get; set; }

            [Required(ErrorMessage = "La cifra del TOTAL es requerido")]
            [Range(0, 99999)]
            [DisplayName("TOTAL")]
            public int Total { get; set; }

            [Required(ErrorMessage = "El dato editable es requerido")]
            [DisplayName("Es Editable")]
            public bool Editable { get; set; }

            [Required(ErrorMessage = "El dato Estado es requerido")]
            [DisplayName("Estado")]
            public string status { get; set; }
        }
    }
}
