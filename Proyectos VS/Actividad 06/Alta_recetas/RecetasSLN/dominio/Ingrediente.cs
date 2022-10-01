using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    public class Ingrediente
    {
        public int Id_ingrediente { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }

        public Ingrediente(int id, string nom, string uni)
        {
            Id_ingrediente = id;
            Nombre = nom;
            Unidad = uni;
        }
    }
}