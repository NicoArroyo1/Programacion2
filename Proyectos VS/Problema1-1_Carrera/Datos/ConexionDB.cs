using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_1_Carrera.Datos
{
    public class ConexionDB
    {
        private SqlConnection cnn;

        public ConexionDB()
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = Properties.Resources.CadenaConexion;
        }

        public DataTable SPConsulta(string nombreSP)
        {
            DataTable tabla = new DataTable();

            cnn.Open();

            SqlCommand cmd = new SqlCommand(nombreSP, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd.ExecuteReader());

            cnn.Close();

            return tabla;
        }

        public DataTable ConsultaMaterias(string sp, int carrera)
        {
            DataTable tabla = new DataTable();

            cnn.Open();

            SqlCommand cmd = new SqlCommand(sp, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@carrera", carrera);

            tabla.Load(cmd.ExecuteReader());

            cnn.Close();

            return tabla;
        }

        /* -- PENDIENTE --
         * ¡¡¡ GENERALIZAR PARA HACER UN INSERT, UPDATE, ALTER... !!!
         * 
        public int EjecutarSP(string nombre_sp)
        {
            int filas;
            cnn.Open();
            cmd = new SqlCommand(nombre_sp, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue();
            filas = cmd.ExecuteNonQuery();
            cnn.Close();
            return filas;
        }
        */

    }
}
