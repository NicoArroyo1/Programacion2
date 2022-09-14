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
            cnn.ConnectionString = Properties.Resources.CadenaConexion1;
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

        public int InsertarCarrera(string carrera, DataGridView dgvMaterias)
        {
            cnn.Open();
            SqlTransaction t = null;
            t = cnn.BeginTransaction();

            int id = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertar_carrera", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", carrera);

                SqlParameter param = new SqlParameter("@id_carrera", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                id = Convert.ToInt32(param.Value);

                foreach (DataGridViewRow fila in dgvMaterias.Rows)
                {
                    int cod = Convert.ToInt32(fila.Cells[0].Value);
                    string nom = fila.Cells[1].Value.ToString();
                    Asignatura materia = new(cod, nom);

                    int anio = Convert.ToInt16(fila.Cells[2].Value);

                    int cuat = Convert.ToInt16(fila.Cells[3].Value);

                    DetalleCarrera detCarrera = new(id, materia, anio, cuat);

                    this.InsertarDetalle(detCarrera, t);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al intentar cargar los datos", "Carga de datos", MessageBoxButtons.OK,MessageBoxIcon.Error);
                t.Rollback();
            }
            finally
            {
                t.Commit();
                cnn.Close();
            }

            return id;

        }
        
        public int InsertarDetalle(DetalleCarrera det, SqlTransaction t)
        {
            int filas;

            cnn.Open();

            SqlCommand cmdDet = new SqlCommand("sp_insertar_detalle", cnn, t);
            cmdDet.CommandType = CommandType.StoredProcedure;

            cmdDet.Parameters.AddWithValue("@carrera", det.Id_Carrera);
            cmdDet.Parameters.AddWithValue("@asign", det.Asignatura.Id_Asignatura);
            cmdDet.Parameters.AddWithValue("@anio", det.Año_Cursado);
            cmdDet.Parameters.AddWithValue("@cuat", det.Cuatrimestre);

            filas = cmdDet.ExecuteNonQuery();

            cnn.Close();

            return filas;
        }

    }
}
