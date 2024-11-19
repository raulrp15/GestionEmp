using System.ComponentModel.DataAnnotations.Schema;

namespace CapaENT
{
    public class ClsPersona
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; }
        [Column("FechaNacimiento")]
        public DateTime FechaNac { get; set; }
        [Column("IDDepartamento")]
        public int IdDept { get; set; }
        #endregion
    }
}
