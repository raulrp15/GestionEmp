using CapaDAL.Conexion;
using CapaENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class ClsListadoDAL
    {
        /// <summary>
        /// Funcion que crea una lista y le inserta las personas de la tabla Personas de la base de datos
        /// </summary>
        /// <returns>Lista de personas</returns>
        public static List<ClsPersona> GetListadoPersonasDAL()
        {
            SqlConnection miConexion = new SqlConnection();

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona;

            miConexion.ConnectionString
            = ("server=pajaritoscity.database.windows.net;database=BDRaulRopa;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Personas";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.Id = (int)miLector["ID"];
                        oPersona.Nombre = (string)miLector["Nombre"];
                        oPersona.Apellidos = (string)miLector["Apellidos"];
                        if (miLector["Telefono"] != System.DBNull.Value)
                        {
                            oPersona.Telefono = (string)miLector["Telefono"];
                        }
                        if (miLector["Direccion"] != System.DBNull.Value)
                        {
                            oPersona.Direccion = (string)miLector["Direccion"];
                        }
                        if (miLector["Foto"] != System.DBNull.Value)
                        {
                            oPersona.Foto = (string)miLector["Foto"];
                        }
                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.FechaNac = (DateTime)miLector["FechaNacimiento"];
                        }
                        if (miLector["IdDepartamento"] != System.DBNull.Value)
                        {
                            oPersona.IdDept = (int)miLector["IDDepartamento"];
                        }
                        listadoPersonas.Add(oPersona);
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return listadoPersonas;
        }

        public static ClsPersona GetPersonasPorIdDAL(int id)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miCommand = new SqlCommand();
            SqlDataReader miLector;
            ClsPersona persona;

            miConexion.ConnectionString
            = ("server=pajaritoscity.database.windows.net;database=BDRaulRopa;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");



            return persona;
        }
    }
}
