using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaAutistaDotnet.Application.Interfaces
{
  public interface IBaseService<T> where T : class
  {
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> GetByName(string texto);

    T GetById(int? id);

    T Add(T objeto);
    T Update(T objeto);
    void Remove(int id);
  }
}
