using System.Collections.Generic;
using System.Web.Mvc;

namespace clinicamedica.Models
{
    public class ListaHorarios
    {
        public static IEnumerable<SelectListItem> getHorarios()
        {
            IList<SelectListItem> time = new List<SelectListItem>
                {
                
                    new SelectListItem {Text="08:00", Value = "08:00"},
                    new SelectListItem {Text="08:30", Value = "08:30"},
                    new SelectListItem {Text="09:00", Value = "09:00"},
                    new SelectListItem {Text="09:30", Value = "09:30"},
                    new SelectListItem {Text="10:00", Value = "10:00"},
                    new SelectListItem {Text="10:30", Value = "10:30"},
                    new SelectListItem {Text="11:00", Value = "11:00"},
                    new SelectListItem {Text="11:30", Value = "11:30"},
                    new SelectListItem {Text="13:30", Value = "13:30"},
                    new SelectListItem {Text="14:00", Value = "14:00"},
                    new SelectListItem {Text="14:30", Value = "14:30"},
                    new SelectListItem {Text="15:00", Value = "15:00"},
                    new SelectListItem {Text="15:30", Value = "15:30"},
                    new SelectListItem {Text="16:00", Value = "16:00"},
                    new SelectListItem {Text="16:30", Value = "16:30"},
                    new SelectListItem {Text="17:00", Value = "17:00"},
                    new SelectListItem {Text="17:30", Value = "17:30"},
                    new SelectListItem {Text="18:00", Value = "18:00"},
                    new SelectListItem {Text="18:30", Value = "18:30"}

                };
            return time;
            
        }
    }
}