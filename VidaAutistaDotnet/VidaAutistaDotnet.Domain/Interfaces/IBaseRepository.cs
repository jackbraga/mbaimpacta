using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaAutistaDotnet.Domain.Interfaces
{
  public interface IBaseRepository<T> where T : class
  {
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    T GetById(int? id);

    IEnumerable<T> GetByName(string texto);

    T Add(T objeto);
    T Update(T objeto);

    void Remove(int id);
  }
}
