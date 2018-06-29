using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRegistroCasillas.Models
{
    public class Login
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El Nombre de Usuario es requerido")]
        public string UsernameLogin { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La Contraseña es requerida")]
        [DataType(DataType.Password)]
        public string PasswordLogin { get; set; }

        [Display(Name = "Tipo")]
        public string Type { get; set; }
    }
}