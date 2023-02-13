
using MySql.Data.MySqlClient;
using System.Management;

namespace CRUDCORE.Datos
{
    public class Conexion

    {
        public string getCadenaSQL()
        {
            return "server=localhost;user=root;password='';database=DBCRUDCORE;";
        }
   


    }
}
