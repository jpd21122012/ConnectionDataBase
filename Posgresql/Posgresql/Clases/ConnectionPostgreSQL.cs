using Npgsql;
using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Posgresql.Clases
{
    public class ConnectionPostgreSQL
    {
        public NpgsqlConnection conection = new NpgsqlConnection();//Objeto para usar las funciones de abrir o cerrar la conexion
        //Se crea un string con los datos para la conexion
        public string cadenaConexion = "Server=localhost;Port=5432;User Id=postgres;Password=000pipo.182;Database=postgres";
        public NpgsqlConnection AbreConexion()
        {
            if (!string.IsNullOrWhiteSpace(cadenaConexion))
            {
                try //intenta hacer conexion a la base de datos, si sucede nos manda un mensaje de exito, de lo contrario nos dice la falla 
                {
                    conection = new NpgsqlConnection(cadenaConexion);
                    conection.Open();
                    Console.WriteLine("Exitosa la conexion a la base de datos");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fallo la conexion a la base de datos : " + ex);
                    conection.Close();
                }
            }
            return conection;
        }

        public void guardarimei(double imei) {
            try
            {
                conection = new NpgsqlConnection(cadenaConexion);
                // Se abre la conexion
                conection.Open();
                Console.WriteLine("Exitosa la conexion a la base de datos");
                //Se declara la consulta deseada, en este caso se van a guardar las imagenes en la tabla publica post,en sus respectivos campos
                string consulta = "INSERT INTO public.prueba(as) VALUES(@as)";
                NpgsqlCommand comand = new NpgsqlCommand(consulta, conection);
                // Se definen los parametros de las consultas
                Console.WriteLine(comand.CommandText);
                comand.Parameters.Add("@as", NpgsqlTypes.NpgsqlDbType.Real);
                comand.Parameters["@as"].Value = imei;
                comand.ExecuteNonQuery();
                Console.WriteLine("Info agregada !!!");
                Thread.Sleep(5000);
                conection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fallo la info !!!\n" + ex);
                Thread.Sleep(5000);
               conection.Close();
            }
        }  
    public static String StartADB(String instruccion)
        {
            string result = "";

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "C:/Program Files (x86)/Android/android-sdk/platform-tools/adb.exe ";
            startInfo.Arguments = instruccion;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            using (Process process = Process.Start(startInfo))
            {
                using (System.IO.StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
    }
}
