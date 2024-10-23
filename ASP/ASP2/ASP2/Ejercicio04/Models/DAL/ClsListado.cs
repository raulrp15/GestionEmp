using Ejercicio04.Models.ENT;
using System.Collections.Generic;

namespace Ejercicio04.Models.DAL
{
    public class ClsListado
    {
        /// <summary>
        /// Funcion que devuelve un listado de personas
        /// </summary>
        /// <returns>Listado de personas</returns>
        public static List<ClsPersona> GetPersonas()
        {
            return new List<ClsPersona>
            {
               new ClsPersona{Nombre = "Raul", Apellidos = "Romera Pavon", Edad = 19, IdDepartamento = 1},
               new ClsPersona{Nombre = "Isaac", Apellidos = "Romera Pavon", Edad = 26, IdDepartamento = 2},
               new ClsPersona{Nombre = "Pedro", Apellidos = "Andromeda Milano", Edad = 22, IdDepartamento = 1},
               new ClsPersona{Nombre = "Julian", Apellidos = "Lopez Maldonado", Edad = 19, IdDepartamento = 2},
               new ClsPersona{Nombre = "Enrique", Apellidos = "Gonzalez Montes", Edad = 19, IdDepartamento = 3},
               new ClsPersona{Nombre = "Julio", Apellidos = "Saez Fuentes", Edad = 19, IdDepartamento = 4},
               new ClsPersona{Nombre = "Bernardo", Apellidos = "Norte Sur", Edad = 19, IdDepartamento = 3},
            };
        }

        /// <summary>
        /// Funcion que crea y devuelve un listado de departamentos
        /// </summary>
        /// <returns>Listado de departamentos</returns>
        public static List<ClsDepartamento> GetDepartamentos()
        {
            return new List<ClsDepartamento>
            {
                new ClsDepartamento{Id = 1, Nombre= "I+D"},
                new ClsDepartamento{Id = 2, Nombre= "Finanzas"},
                new ClsDepartamento{Id = 3, Nombre= "Recursos Humanos"},
                new ClsDepartamento{Id = 4, Nombre= "Marketing"},
            };
        }
    }
}
