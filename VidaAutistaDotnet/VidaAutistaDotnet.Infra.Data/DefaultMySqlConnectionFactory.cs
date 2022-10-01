using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaAutistaDotnet.Infra.Data
{
  public class DefaultMySqlConnectionFactory : IConnectionFactory
  {
    public IDbConnection Connection()
    {
      return new MySqlConnection("Server=localhost;Database=vidaautista;Uid=root;Pwd=root;");
    }
  }
}
