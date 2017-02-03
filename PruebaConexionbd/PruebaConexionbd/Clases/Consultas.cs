using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PruebaConexionbd.Clases
{
    public class Consultas
    {
        private Conexion conexionbd;
        private MySqlCommand Query = new MySqlCommand();
        private MySqlConnection Con;
        private MySqlDataReader consultar;
        private static string servidor = "localhost";
        private static string usuario = "root";
        private static string Bd = "buscaminas";
        private static string password = "";
        private string sql = ";server=" + servidor + ";user id=" + usuario + ";database=" + Bd + ";password=" + password;
        public Consultas()
        {
            this.conexionbd = new Conexion();
        }
        public void ObtenerUsuario(string user)
        {
            int row = 0;
            try
            {
                Con= new MySqlConnection();
                Con.ConnectionString = sql;
                Con.Open();
                Query.CommandText = "SELECT nombres.nombre FROM nombres";
                Query.Connection = Con;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    string nombre = consultar.GetString(0);
                    Console.WriteLine(nombre);
                }
                Con.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
