using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;

namespace CapaDAL.Conexion
{
    public class ClsConexion
    {
        SqlConnection miConexion;

        public void ConectarBD()
        {
            try
            {
                miConexion = new SqlConnection();
                miConexion.ConnectionString = "server=pajaritoscity.database.windows.net;database=BDRaulRopa;uid=Usuario;pwd=LaCampana123;trustServerCertificate=true;";

                miConexion.Open();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DesconectarBD()
        {
            miConexion.Close();
        }
    }
}
