using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Management;
using Microsoft.AspNetCore.Mvc;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();


            using (MySqlConnection conexion = new MySqlConnection(cn.getCadenaSQL())) { 
                conexion.Open();
               MySqlCommand cmd = new MySqlCommand ("sp_Listar ", conexion); 
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {
                        oLista.Add(new ContactoModel() { 
                        
                         IdContacto = Convert.ToInt32(dr["IdContacto"]),
                         Nombre = dr["Nombre"].ToString(),
                         Telefono = dr["Telefono"].ToString(),
                         Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return oLista; 
        }

        

        public ContactoModel Obtener(int IdContacto)
        {
           
            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (MySqlConnection conexion = new MySqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("sp_Obtener ", conexion);
                cmd.Parameters.AddWithValue("p_IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read() && Convert.ToInt32(dr["IdContacto"]) == IdContacto)
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oContacto;
        }


        public bool Guardar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (MySqlConnection conexion = new MySqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_Guardar", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", ocontacto.Nombre);
                        cmd.Parameters.AddWithValue("@Telefono", ocontacto.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", ocontacto.Correo);
                        cmd.ExecuteNonQuery();
                    }
                }
                rpta = true; 

            }
            catch (Exception e)
            {
                string error = e.Message; 
                rpta = false;
            }

            return rpta; 
        }


        public bool Editar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (MySqlConnection conexion = new MySqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContac", ocontacto.IdContacto);
                    cmd.Parameters.AddWithValue("new_Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("new_Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("new_Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int result = cmd.ExecuteNonQuery();

                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (MySqlConnection conexion = new MySqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdContac", ocontacto.IdContacto);
                 
                    cmd.CommandType = CommandType.StoredProcedure;
                    int result = cmd.ExecuteNonQuery();

                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }


    }
}
