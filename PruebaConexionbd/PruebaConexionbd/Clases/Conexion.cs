using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PruebaConexionbd.Clases
{
    public class Conexion
    {
      private  MySqlCommand Query = new MySqlCommand();
        private MySqlConnection Con;
        private MySqlDataReader consultar;
        private static string servidor = "localhost";
        private static string usuario = "root";
        private static string Bd = "buscaminas";
        private static string password = "";
        private string sql = ";server=" + servidor + ";user id=" + usuario + ";database=" + Bd + ";password=" + password;
        public void ConexionBD() {
        
         try
            {
                Con = new MySqlConnection();
                Con.ConnectionString = sql;
                Con.Open();
                Console.WriteLine("Conectado con éxito a la base de datos "+ Bd);
                Con.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
