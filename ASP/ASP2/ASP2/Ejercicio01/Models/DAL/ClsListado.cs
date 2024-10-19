namespace Ejercicio01.Models.DAL
{
    public class ClsListado
    {
        public List<ClsPersona> listado = new List<ClsPersona> 
        { 
            new ClsPersona{Nombre = "Raul", Apellidos = "Romera Pavón", Edad = 19 },
            new ClsPersona{Nombre = "Draco", Apellidos = "Malisioso", Edad = 40 },
            new ClsPersona{Nombre = "Isaac", Apellidos = "Romera Pavón", Edad = 26 },
            new ClsPersona{Nombre = "Nuria", Apellidos = "Casas Sanchez", Edad = 22 },
            new ClsPersona{Nombre = "Hue", Apellidos = "Lees Mal", Edad = 99 },
        };
    }
}
