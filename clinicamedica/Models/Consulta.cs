using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicamedica.Models
{
    public class Consulta
    {
        [Key]
        public int IDConsulta { get; set; }

        public int IDPaciente { get; set; }

        public int IDMedico { get; set; }

        [Display(Name = "Plano de Saúde")]
        [DisplayFormat(NullDisplayText ="Não Possui")]
        public string PlanoDeSaude { get; set; }
        
        [Required(ErrorMessage ="O campo data é obrigatório")]
        [DataType(DataType.Date, ErrorMessage ="Insira a data no formato dd/mm/aaaa")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O campo horário é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm tt}")]
        [DataType(DataType.Time)]
        [Display(Name = "Horário")]
        public DateTime Time { get; set; }
        
        public bool Comparecimento { get; set; }

        public virtual Paciente paciente { get; set; }
        public virtual Medico medico { get; set; }


    }
}