using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace clinicamedica.Models
{
    public class Administrador
    {
        [Key]
        public int IDAdmin { get; set; }

        [Required(ErrorMessage = "Digite o nome do administrador")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "O e-mail digitado não está no formato correto")]
        [Required(ErrorMessage = "Digite o e-mail do administrador")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha do administrador")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
       
        [Required(ErrorMessage = "Digite o RG do administrador")]
        [MaxLength(10, ErrorMessage = "O RG inserido não é válido")]
        public string RG { get; set; }
        [MaxLength(15, ErrorMessage = "O telefone inserido não é válido")]
        [Required(ErrorMessage = "Digite o telefone do administrador")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Digite o endereço do administrador")]
        [Display(Name ="Endereço")]
        public string Endereco { get; set; }
    }
}