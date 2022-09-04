using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_1_Carrera.Dominio
{
    public class DetalleCarrera
    {
        public int Id_Detalle { get; set; }
        public int Id_Carrera { get; set; }
        public Asignatura Asignatura { get; set; }
        public int Año_Cursado { get; set; }
        public int Cuatrimestre { get; set; }

        public DetalleCarrera(int carrera, Asignatura asignatura, int año, int cuat)
        {
            Id_Carrera = carrera;
            Asignatura = asignatura;
            Año_Cursado = año;
            Cuatrimestre = cuat;
        }

        public override string ToString()
        {
            return Asignatura.ToString() + " | " + Año_Cursado + " | " + Cuatrimestre;
        }
    }
}