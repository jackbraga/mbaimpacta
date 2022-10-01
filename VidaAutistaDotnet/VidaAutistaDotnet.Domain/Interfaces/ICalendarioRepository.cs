using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaAutistaDotnet.Domain.Entities;

namespace VidaAutistaDotnet.Domain.Interfaces
{
  public interface ICalendarioRepository: IBaseRepository<Calendario>
  {
    public IEnumerable<Calendario> GetCalendarioUsuario(int idUsuario);

  }
}
