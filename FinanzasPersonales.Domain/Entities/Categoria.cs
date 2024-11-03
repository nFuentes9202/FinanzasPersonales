using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Domain.Entities
{
    public class Categoria
    {
        public int CategoriaID { get; private set; } 
        public string Nombre { get; private set; }    

        // Constructor
        public Categoria(int categoriaID, string nombre)
        {
            CategoriaID = categoriaID;
            Nombre = nombre;
        }

        // Método para actualizar el nombre de la categoría
        public void AsignarNombre(string nombre)
        {
            Nombre = nombre;
        }
    }
}
