using Ejercicio04.Models.ENT;
using Ejercicio04.Models.DAL;
namespace Ejercicio04.Models.VM
{
    public class ClsEditarPersonaVM : ClsPersona
    {
        public List<ClsDepartamento> Departamentos { get; }

        public ClsEditarPersonaVM() {
            Departamentos = ClsListado.GetDepartamentos();
        }
    }
}
