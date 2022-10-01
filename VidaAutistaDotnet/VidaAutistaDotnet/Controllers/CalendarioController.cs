using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using VidaAutistaDotnet.API.ViewModels;
using VidaAutistaDotnet.Application.DTO;
using VidaAutistaDotnet.Application.Interfaces;
using VidaAutistaDotnet.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VidaAutistaDotnet.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CalendarioController : ControllerBase
  {

    private readonly ICalendarioService _calendarioService;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public CalendarioController(ICalendarioService calendarioService, ILogger<CalendarioController> logger, IMapper mapper)
    {
      _calendarioService = calendarioService;
      _logger = logger;
      _mapper = mapper;
    }



    // GET: api/<CalendarioController>
    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        var calendarios = _calendarioService.GetAll();
        var result = _mapper.Map<IEnumerable<CalendarioViewModel>>(calendarios);

        return Ok(result);
      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
          $"Erro ao tentar recuperar calendário\n Descrição do erro: {ex.Message}");
      }
    }

    // GET api/<CalendarioController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {

      try
      {
        var calendario = _calendarioService.GetById(id);
        return Ok(_mapper.Map<CalendarioViewModel>(calendario));
      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
          $"Erro ao tentar recuperar calendário\n Descrição do erro: {ex.Message}");
      }
    }

    [HttpGet("calendarioUsuario/{idUsuario}")]
    public IActionResult GetCalendarioUsuario(int idUsuario)
    {

      try
      {
        var calendarios = _calendarioService.GetCalendarioUsuario(idUsuario);
        if (calendarios.Count() == 0)
        {
          return NotFound("Usuário não encontrado na base");
        }
        else
        {
          return Ok(_mapper.Map<IEnumerable<CalendarioViewModel>>(calendarios));
        }
      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
          $"Erro ao tentar recuperar calendário\n Descrição do erro: {ex.Message}");
      }
    }

    [HttpPost]
    public IActionResult Post(CalendarioViewModel calendario)
    {
      try
      {
        var calendarioDto = _mapper.Map<CalendarioDTO>(calendario);
        var retorno = _calendarioService.Add(calendarioDto);
        // Created(retorno);

        return this.StatusCode(StatusCodes.Status201Created, retorno);
      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
          $"Erro ao tentar inserir registro \n Descrição do erro: {ex.Message}");
      }

    }


    [HttpPut]
    public IActionResult Put(CalendarioViewModel calendario)
    {

      try
      {
        var calendarioDto = _mapper.Map<CalendarioDTO>(calendario);
        var retorno = _calendarioService.Update(calendarioDto);

        return this.StatusCode(StatusCodes.Status201Created, retorno);
      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
          $"Erro ao tentar atualizar registro \n Descrição do erro: {ex.Message}");
      }


    }

    // DELETE api/<CalendarioController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      try
      {
        _calendarioService.Remove(id);

        return Ok();

      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
          $"Erro ao tentar remover registro\n Descrição do erro: {ex.Message}");
      }


    }
  }
}
