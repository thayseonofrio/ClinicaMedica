using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicamedica.Models
{
    public class Secretaria
    {
        [Key]
        public int IDSecretaria { get; set; }
        [Required(ErrorMessage = "Digite o nome da secretária")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O e-mail digitado não está no formato correto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Senha { get; set; }
        
        [Required(ErrorMessage = "Digite o RG da secretária")]
        [MaxLength(10, ErrorMessage = "O RG inserido não é válido")]
        public string RG { get; set; }
        [Required(ErrorMessage = "Digite o telefone da secretária")]
        [MaxLength(15, ErrorMessage = "O telefone inserido não é válido")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Digite o endereço da secretária")]
        [Display(Name ="Endereço")]
        public string Endereco { get; set; }
    }
}