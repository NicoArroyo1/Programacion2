
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpinteria_1w3.Dominio
{
    internal class Producto
    {
        public int Id_producto { get; set; }

        public string Nombre { get; set; }

        public float Precio { get; set; }

        public bool Activo { get; set; }

        public Producto(int id, string nom, float precio, bool activo)
        {
            Id_producto = id;
            Nombre = nom;
            Precio = precio;
            Activo = activo;
        }
    }
}
