using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Punto_venta.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string des_usuario { get; set; }
        public int id_perfil { get; set; }
        public string des_perfil { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name ="Teléfono")]
        public string telefono { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required][StringLength(8,MinimumLength = 8,ErrorMessage = "No es valido")]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}