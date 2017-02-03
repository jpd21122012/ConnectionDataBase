using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Posgresql.Clases;
using System.IO;
using System.Data.SqlClient;

namespace Posgresql
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            ConnectionPostgreSQL bd = new ConnectionPostgreSQL();
               //bd.AbreConexion();
               
            string imei = "shell dumpsys iphonesubinfo";
            imei = ConnectionPostgreSQL.StartADB(imei);
            char[] arreglo = imei.TrimEnd('\n').TrimEnd('\r').ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int i = arreglo.Length - 15; i < arreglo.Length; i++)
            {
                if (arreglo[i] != ' ')
                {
                    sb.Append(arreglo[i], 1);
                }
            }
            imei = sb.ToString();
            double resultimei;
            resultimei = Convert.ToDouble(imei);
            bd.guardarimei(resultimei);
        }
    }
}
