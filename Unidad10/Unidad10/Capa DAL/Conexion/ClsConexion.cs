using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;

namespace Capa_DAL.Conexion
{
    public class ClsConexion
    {
        SqlConnection miConexion = new SqlConnection();

        public string ConectarBD()
        {
            try
            {
                miConexion.ConnectionString = "server=pajaritoscity.database.windows.net;database=BDRaulRopa;uid=Usuario;pwd=LaCampana123;trustServerCertificate=true;";

                miConexion.Open();
                return "Conexion exitosa";
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return "Error en el servidor";
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return "Error de operación";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error inesperado";
            }
            finally
            {
                miConexion.Close();
            }
        }
    }
}
