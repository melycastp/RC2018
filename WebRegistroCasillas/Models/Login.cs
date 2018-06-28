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
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La Contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Tipo")]
        public string Type { get; set; }
    }
}