using EjercicioAzureMAUI.ViewModels.Utils;
using CapaDAL.Conexion;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CapaDAL;
using CapaENT;
using Capa_DAL;
namespace EjercicioAzureMAUI.ViewModels
{
    public class ConectarVM : INotifyPropertyChanged
    {
        #region Atributo
        private string estado = "";
        private ClsConexion conexion = new ClsConexion();
        private bool conectado = false;
        private List<ClsPersona> listado;
        #endregion

        #region Propiedades
        public List<ClsPersona> Listado { get { return listado; } }
        public string Estado { get { return estado; } }
        public DelegateCommand ConectarCommand { get; }
        public DelegateCommand DesconectarCommand { get; }
        #endregion

        #region Constructores
        public ConectarVM()
        {
            ConectarCommand = new DelegateCommand(ConectarExecute);
            DesconectarCommand = new DelegateCommand(DesconectarExecute);
        }
        #endregion

        #region Comandos
        /// <summary>
        /// Metodo privado que conecta con la base de datos
        /// </summary>
        private void ConectarExecute()
        {
            try
            {
                conexion.ConectarBD();
                estado = "Conexion Exitosa";
                conectado = true;
                listado = ClsListadoDAL.GetListadoPersonasDAL();
            }
            catch (Exception ex)
            {
                estado = "Error en la conexion";
            }
            finally
            {
                NotifyPropertyChanged("Estado");
                NotifyPropertyChanged("Listado");
            }
        }

        /// <summary>
        /// Metodo privado que desconecta de la base de datos que se encuentra
        /// </summary>
        private void DesconectarExecute()
        {
            try
            {
                conexion.DesconectarBD();
                estado = "Desconexion exitosa";
                conectado = false;
                listado = null;
            }
            catch (Exception ex)
            {
                estado = "Error en la desconexion";
            }
            finally
            {
                NotifyPropertyChanged("Estado");
                NotifyPropertyChanged("Listado");
            }
        }
        #endregion

        #region Notify
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
