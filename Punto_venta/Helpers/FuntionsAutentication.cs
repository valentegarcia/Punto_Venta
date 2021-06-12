using MySql.Data.MySqlClient;
using Punto_venta.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Punto_venta.Helpers
{
    public class FuntionsAuthentication
    {
        public Usuario RegistrarUsuario(){
            Usuario obj_usuario = new Usuario();
            ConexionMysql obj_ConexionMySql = new ConexionMysql();
            obj_ConexionMySql.Conexion();
            return obj_usuario;
        }

        public Usuario ObtenerUsuario(string usuario, string psw) {
            Usuario obj_usuario = new Usuario();
            ConexionMysql obj_ConexionMySql = new ConexionMysql();
            obj_ConexionMySql.Conexion();
            List<Tuple<string, string, string>> parametros = new List<Tuple<string, string, string>>();
            Tuple<string, string, string> param1 = new Tuple<string, string, string>(
                    usuario,
                    "VARCHAR",
                    "@USUARIO"
                );
            parametros.Add(param1);
            Tuple<string, string, string> param2 = new Tuple<string, string, string>(
                    psw,
                    "VARCHAR",
                    "@PASS"
                );
            parametros.Add(param2);
            string query = "PA_OBTENER_USUARIO";
            DataTable DT =  obj_ConexionMySql.ConsultaDT(query,parametros);
            if (DT.Rows.Count > 0) {
                obj_usuario.id_perfil = int.Parse(DT.Rows[0]["ID_PERFIL"].ToString());
                obj_usuario.id_usuario = int.Parse(DT.Rows[0]["ID_USUARIO"].ToString());
                obj_usuario.nombre = DT.Rows[0]["NOMBRE"].ToString();
                obj_usuario.des_usuario = DT.Rows[0]["DES_USUARIO"].ToString();
                obj_usuario.telefono = DT.Rows[0]["TELEFONO"].ToString();
                obj_usuario.email = DT.Rows[0]["EMAIL"].ToString();
                obj_usuario.des_perfil = DT.Rows[0]["DES_PERFIL"].ToString();
            }
            return obj_usuario;
        }
    }
}