using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using PruebaConexionbd.Clases;

namespace PruebaBaseDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Conexion2 con2 = new Conexion2();
            con2.Save();
         //   Conexion conexion = new Conexion();
        //    Consultas consulta = new Consultas();
       //     conexion.ConexionBD();
          //  consulta.ObtenerUsuario("");
            Console.Read();
        }
    }
}
