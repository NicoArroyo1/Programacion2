using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpinteria_1w3.Dominio
{
    internal class DetallePresupuesto
    {
        public int Nro_detalle { get; set; }
        public int Nro_presup { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public DetallePresupuesto(int cant,Producto p)
        {
            Cantidad = cant;
            Producto = p;
        }

        public float SubTotal()
        {
            return Producto.Precio * Cantidad;
        }
    }
}
