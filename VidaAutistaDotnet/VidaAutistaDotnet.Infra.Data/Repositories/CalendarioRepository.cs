using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaAutistaDotnet.Domain.Entities;
using VidaAutistaDotnet.Domain.Interfaces;
using static System.Collections.Specialized.BitVector32;

namespace VidaAutistaDotnet.Infra.Data.Repositories
{
  public class CalendarioRepository : ICalendarioRepository
  {

    private readonly IConnectionFactory _connection;

    public CalendarioRepository(IConnectionFactory connection)
    {
      _connection = connection;
    }

    public Calendario Add(Calendario objeto)
    {
     // id_calendario, id_usuario, nome_medico, especialidade_medico, anotacoes, data_hora_evento
      string sql = "INSERT INTO calendario(id_usuario,nome_medico,especialidade_medico, anotacoes, data_hora_evento) " +
        "VALUES(@idUsuario,@nomeMedico,@especialidadeMedico,@anotacoes,@dataHoraEvento) ";

      using (var connection = _connection.Connection())
      {
        connection.Open();
        connection.Query<Calendario>(sql, new
        {
          idUsuario = objeto.IdUsuario,
          nomeMedico = objeto.NomeMedico,
          especialidadeMedico= objeto.EspecialidadeMedico,
          anotacoes= objeto.Anotacoes,
          dataHoraEvento= objeto.DataHoraEvento          
        });
        return objeto;
      }
    }

    public IEnumerable<Calendario> GetAll()
    {
      string sql = "SELECT id_calendario, id_usuario, nome_medico, especialidade_medico, anotacoes, data_hora_evento " +
               "FROM calendario ";

      using (var connection = _connection.Connection())
      {
        SqlMapper.SetTypeMap(typeof(Calendario), new CustomPropertyTypeMap(
        typeof(Calendario), (type, columnName) => type.GetProperties().FirstOrDefault(prop =>
        prop.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(attr => attr.Name == columnName))));

        connection.Open();
        return connection.Query<Calendario>(sql);
      }
    }

    public Task<IEnumerable<Calendario>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Calendario GetById(int? id)
    {
      string sql = "SELECT id_calendario, id_usuario, nome_medico, especialidade_medico, anotacoes, data_hora_evento " +
                         "FROM calendario " +
                         "WHERE id_calendario=@id; ";

      using (var connection = _connection.Connection())
      {
        connection.Open();
        return connection.QuerySingleOrDefault<Calendario>(sql, new
        {
          id = id
        });
      }
    }

    public IEnumerable<Calendario> GetByName(string texto)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Calendario> GetCalendarioUsuario(int idUsuario)
    {


      string sql = "SELECT id_calendario, id_usuario, nome_medico, especialidade_medico, anotacoes, data_hora_evento " +
                    "FROM calendario " +
                    "WHERE id_usuario=@idUsuario; ";

      using (var connection = _connection.Connection())
      {
        SqlMapper.SetTypeMap(typeof(Calendario), new CustomPropertyTypeMap(
        typeof(Calendario), (type, columnName) => type.GetProperties().FirstOrDefault(prop =>
        prop.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(attr => attr.Name == columnName))));

        connection.Open();
        return connection.Query<Calendario>(sql, new
        {
          idUsuario = idUsuario
        });
      }
    }

    public void Remove(int id)
    {
      // id_calendario, id_usuario, nome_medico, especialidade_medico, anotacoes, data_hora_evento
      string sql = "DELETE FROM calendario WHERE id_calendario=@idCalendario";

      using (var connection = _connection.Connection())
      {
        connection.Open();
        connection.Query<Calendario>(sql, new
        {
          idCalendario = id
        });
      }
    }

    public Calendario Update(Calendario objeto)
    {
      // id_calendario, id_usuario, nome_medico, especialidade_medico, anotacoes, data_hora_evento
      string sql = "UPDATE calendario SET nome_medico=@nomeMedico,especialidade_medico=especialidadeMedico, " +
        "anotacoes=@anotacoes, data_hora_evento=@dataHoraEvento WHERE id_calendario=@idCalendario ";
        

      using (var connection = _connection.Connection())
      {
        connection.Open();
        connection.Query<Calendario>(sql, new
        {
          idCalendario = objeto.IdCalendario,
          nomeMedico = objeto.NomeMedico,
          especialidadeMedico = objeto.EspecialidadeMedico,
          anotacoes = objeto.Anotacoes,
          dataHoraEvento = objeto.DataHoraEvento

        });
        return objeto;
      }
    }
  }
}
