using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_1_Carrera.Dominio
{
    internal class Asignatura
    {
        public int Id_Asignatura { get; set; }
        public string Nombre { get; set; }

        public Asignatura(string nombre)
        {
            this.Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}