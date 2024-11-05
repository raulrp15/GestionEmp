namespace Entidades
{
    public class Class1
    {
        #region Atributos
        private long id;
        private string nombre;
        private string apellidos;
        private int edad;
        #endregion

        #region Propiedades
        public long Id { get { return id; } set { id = value; } }
        public int Edad { get { return edad; } set { edad = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellidos { get { return apellidos; } set { apellidos = value; } }
        #endregion
    }
}
