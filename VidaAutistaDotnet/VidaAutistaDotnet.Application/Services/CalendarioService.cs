using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaAutistaDotnet.Application.DTO;
using VidaAutistaDotnet.Application.Interfaces;
using VidaAutistaDotnet.Domain.Entities;
using VidaAutistaDotnet.Domain.Interfaces;

namespace VidaAutistaDotnet.Application.Services
{
  public class CalendarioService : ICalendarioService
  {

    private readonly ICalendarioRepository _repository;
    private readonly IMapper _mapper;

    public CalendarioService(ICalendarioRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public CalendarioDTO Add(CalendarioDTO objeto)
    {
      var calendario = _mapper.Map<Calendario>(objeto);
      var result = _repository.Add(calendario);
      return _mapper.Map<CalendarioDTO>(result);
    }

    public bool ExisteUsuario(int idUsuario)
    {
      var usuario = _repository.GetById(idUsuario);

      if (usuario is null)
      {
        return false;
      }
      else
      {
        return true;
      }

    }

    public IEnumerable<CalendarioDTO> GetAll()
    {
      var calendarios = _repository.GetAll();
      return _mapper.Map<IEnumerable<CalendarioDTO>>(calendarios);
    }

    public Task<IEnumerable<CalendarioDTO>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public CalendarioDTO GetById(int? id)
    {
      var calendario = _repository.GetById(id);
      return _mapper.Map<CalendarioDTO>(calendario);
    }

    public IEnumerable<CalendarioDTO> GetByName(string texto)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<CalendarioDTO> GetCalendarioUsuario(int idUsuario)
    {
      var calendarios = _repository.GetCalendarioUsuario(idUsuario);
      return _mapper.Map<IEnumerable<CalendarioDTO>>(calendarios);
    }

    public void Remove(int id)
    {
      _repository.Remove(id);
    }

    public CalendarioDTO Update(CalendarioDTO objeto)
    {
      throw new NotImplementedException();
    }
  }
}
