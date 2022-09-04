using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_1_Carrera.Dominio
{
    public class Carrera
    {
        public int IdCarrera { get; set; }

        public string Nombre { get; set; }

        public List<DetalleCarrera> Detalles { get; }

        public Carrera(string nombre)
        {
            Nombre = nombre;
            Detalles = new List<DetalleCarrera>();
        }

        public void AgregarDetalle(DetalleCarrera detalle)
        {
            if (detalle != null)
                Detalles.Add(detalle);
        }

        public void BorrarDetalle(DetalleCarrera detalle)
        {
            Detalles.Remove(detalle);
        }

        public override string ToString()
        {
            return Nombre + " | " + "\n" + Detalles.ToString();
        }
    }
}