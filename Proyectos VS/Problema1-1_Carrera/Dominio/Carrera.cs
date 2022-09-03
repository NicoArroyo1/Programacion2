using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_1_Carrera.Dominio
{
    internal class Carrera
    {
        public string Nombre { get; set; }

        public string Titulo { get; set; }

        public List<DetalleCarrera> Detalles { get; }

        public Carrera(string nombre, string titulo)
        {
            Nombre = nombre;
            Titulo = titulo;
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
            return Nombre + " | " + Titulo + "\n" + Detalles.ToString();
        }
    }
}