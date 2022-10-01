using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaAutistaDotnet.Application.DTO;
using VidaAutistaDotnet.Domain.Entities;

namespace VidaAutistaDotnet.Application.Interfaces
{
  public interface ICalendarioService : IBaseService<CalendarioDTO>
  {
    public IEnumerable<CalendarioDTO> GetCalendarioUsuario(int idUsuario);

    public bool ExisteUsuario(int idUsuario);
  }
}
