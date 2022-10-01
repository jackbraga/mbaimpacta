using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaAutistaDotnet.Domain.Entities
{
  public class Calendario
  {
    [Column("id_calendario")]
    public int IdCalendario { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("data_hora_evento")]
    public DateTime DataHoraEvento { get; set; }

    [Column("especialidade_medico")]
        public string EspecialidadeMedico { get; set; }

    [Column("nome_medico")]
        public string NomeMedico { get; set; }
    [Column("anotacoes")]
        public string Anotacoes { get; set; }
  }
}
