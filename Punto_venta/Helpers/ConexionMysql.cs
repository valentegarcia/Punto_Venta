using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Punto_venta.Helpers
{
    public class ConexionMysql
    {
        private static MySqlConnection _MySqlConnection;

        public int Conexion() {
            try
            {
                if (_MySqlConnection == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
                    MySqlConnection conexion = new MySqlConnection(connectionString);
                    _MySqlConnection = conexion;                   
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }                                
        }

        public void tipo_parametro(Tuple<string, string, string> item, MySqlParameter param)
        {
            switch (item.Item2)
            {
                case "VARCHAR":
                    param.Value = item.Item1;
                    param.MySqlDbType = MySqlDbType.String;
                    break;
                case "INTEGER":
                    param.Value = int.Parse(item.Item1);
                    param.MySqlDbType = MySqlDbType.String;
                    break;
                default:
                    break;
            }
        }

        public void AgregarParametros(MySqlCommand con, List<Tuple<string, string,string>> tparametros) {
            List<DbParameter> parametros = new List<DbParameter>();
            foreach (Tuple<string, string,string> item in tparametros)
            {
                MySqlParameter param = con.CreateParameter();
                param.ParameterName = item.Item3;
                tipo_parametro(item, param);
                parametros.Add(param);
            }            
            foreach (DbParameter parametro in parametros)
            {
                con.Parameters.Add(parametro);
            }
        }

        public DataTable ConsultaDT(string query,List <Tuple<string,string,string>> tparametros) {
            DataTable DT = new DataTable();
            using (MySqlConnection con =_MySqlConnection) {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;                
                cmd.CommandType = CommandType.StoredProcedure;

                AgregarParametros(cmd, tparametros);

                MySqlDataReader reader = cmd.ExecuteReader();
                DT.Load(reader);
                reader.Close();
            }
            return DT;
        }
    }
}