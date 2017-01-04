using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicamedica.Models
{
    
    public class Paciente
    {
        [Key]
        public int IDPaciente { get; set; }

        [Required(ErrorMessage = "Digite o nome do paciente")]
        public string Nome { get; set; }
        [MaxLength(15)]
        [Required(ErrorMessage ="Digite o telefone do paciente")]
        public string Telefone { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name ="Data de Nascimento")]
        [Required(ErrorMessage = "O campo data é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Insira a data no formato dd/mm/aaaa")]
        public DateTime Nascimento { get; set; }
        [Display(Name ="Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public virtual List<Consulta> Consultas { get; set; }
    }
}