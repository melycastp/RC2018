using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [MetadataType(typeof(VUser))]
    public partial class Usuario
    {
        public class VUser
        {
            [Required(ErrorMessage = "El dato Username es requerido")]
            [DisplayName("Username")]
            public string username { get; set; }

            [Required(ErrorMessage = "El dato Password es requerido")]
            [DisplayName("Password")]
            public string password { get; set; }

            [Required(ErrorMessage = "El dato Nombre Completo es requerido")]
            [DisplayName("Nombre Completo")]
            public string nombreCompleto { get; set; }

            [Required(ErrorMessage = "El dato Tipo es requerido")]
            [DisplayName("Tipo")]
            public string tipo { get; set; }
        }
    }
}
