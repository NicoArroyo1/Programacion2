using Problema1_1_Carrera.Dominio;
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

        public int ProximaCarrera()
        {
            int proxima;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_proximo_nro_carrera", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@proximo", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            proxima = Convert.ToInt32(param.Value);
            cnn.Close();
            return proxima;
        }

        public int InsertarCarrera(string carrera)
        {
            int id;

            cnn.Open();

            SqlCommand cmd = new SqlCommand("sp_insertar_carrera", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", carrera);

            SqlParameter param = new SqlParameter("@id_carrera", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            id = Convert.ToInt32(param.Value);

            cnn.Close();

            return id;
        }
        
        public int InsertarDetalle(DetalleCarrera det)
        {
            int filas;

            cnn.Open();

            SqlCommand cmd = new SqlCommand("sp_insertar_detalle", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@carrera", det.Id_Carrera);
            cmd.Parameters.AddWithValue("@asign", det.Asignatura.Id_Asignatura);
            cmd.Parameters.AddWithValue("@anio", det.Año_Cursado);
            cmd.Parameters.AddWithValue("@cuat", det.Cuatrimestre);

            filas = cmd.ExecuteNonQuery();

            cnn.Close();

            return filas;
        }

    }
}
