using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    public class Receta
    {
        public int Id_receta { get; set; }
        public string Nombre { get; set; }
        public string Cheff { get; set; }
        public int Tipo_receta { get; set; }
        public List<Detalle_Receta> Detalles { get; set; }

        public Receta()
        {
            Detalles = new List<Detalle_Receta>();
        }

        public void AgregarDetalle(Detalle_Receta det)
        {
            Detalles.Add(det);
        }

        public void QuitarDetalle(int posicion)
        {
            Detalles.RemoveAt(posicion);
        }
    }
}
