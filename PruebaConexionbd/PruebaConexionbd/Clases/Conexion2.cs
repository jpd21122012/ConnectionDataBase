using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace PruebaConexionbd.Clases
{
    public class Conexion2
    {
    const string MySqlConnecionString = "Server=localhost; Database=imagen; Username=root; Password=;";
    public MySqlConnection con = new MySqlConnection(MySqlConnecionString);

        public void Save()
     {
            FileStream fs;
            MySqlCommand cmd;
                fs.Close();
                string CmdString = "INSERT INTO imgprop (Image) VALUES(@Image)";
                cmd = new MySqlCommand(CmdString, con);
                cmd.Parameters.Add("@Image", MySqlDbType.MediumBlob);
                cmd.Parameters["@Image"].Value = ImageData;
                con.Open();
                int RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                     Console.WriteLine ("Image saved sucessfully!");
                }
                else
				{
                    Console.WriteLine("Incomplete data!");
              }
                con.Close();
             }catch (Exception ex)  {
                Console.WriteLine(ex.Message);
         }
        finally  {
  if (con.State == ConnectionState.Open)
 {
  con.Close();
}
    }
        }
    }
}