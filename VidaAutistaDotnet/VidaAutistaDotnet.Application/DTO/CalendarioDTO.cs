using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaAutistaDotnet.Application.DTO
{
    public class CalendarioDTO
    {
    public int IdCalendario { get; set; }
    public int IdUsuario { get; set; }
    public DateTime DataHoraEvento { get; set; }
    public string EspecialidadeMedico { get; set; }
    public string NomeMedico { get; set; }
    public string Anotacoes { get; set; }
  }
}
