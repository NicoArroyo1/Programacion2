using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos
{
    public class Helper
    {
        private SqlConnection cnn;

        public Helper()
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = Properties.Resources.CadenaConexion;
        }

        public DataTable ConsultarSP(string nombre_sp)
        {
            DataTable dt = new DataTable();
            
            cnn.Open();
            SqlCommand cmd = new SqlCommand(nombre_sp, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            dt.Load(cmd.ExecuteReader());
            cnn.Close();

            return dt;
        }

        public bool InsertarMD(Receta receta)
        {
            bool aux = false;
            SqlTransaction t = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();

                //configuro cmd para insertar Maestro
                SqlCommand cmdMaestro = new SqlCommand("SP_INSERTAR_RECETA", cnn, t);
                cmdMaestro.CommandType = CommandType.StoredProcedure;

                //parametros de entrada
                cmdMaestro.Parameters.AddWithValue("@tipo_receta", receta.Tipo_receta);
                cmdMaestro.Parameters.AddWithValue("@cheff", receta.Cheff);
                cmdMaestro.Parameters.AddWithValue("@nombre", receta.Nombre);

                //configuro param de salida para recibir el id del maestro
                SqlParameter paramSalida = new SqlParameter();
                paramSalida.ParameterName = "@id";
                paramSalida.DbType = DbType.Int32;
                paramSalida.Direction = ParameterDirection.Output;

                cmdMaestro.Parameters.Add(paramSalida);

                //ejecuto cmdMaestro y guardo el identity
                cmdMaestro.ExecuteNonQuery();
                int idMaestro = (int)paramSalida.Value;

                //para ingresar cada detalle del maestro
                SqlCommand cmdDetalle = null;
                foreach (Detalle_Receta det in receta.Detalles)
                {
                    //configuro cmd para insertar el detalle
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    //parametros de entrada
                    cmdDetalle.Parameters.AddWithValue("@id_receta", idMaestro);
                    cmdDetalle.Parameters.AddWithValue("@id_ingrediente", det.Ingrediente.Id_ingrediente);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", det.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                }

                t.Commit();
                aux = true;
            }
            catch (Exception e)
            {
                if(t != null)//si "t" tiene un error almacenado
                {
                    t.Rollback();
                }
            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)//si la conex existe o esta abierta
                {
                    cnn.Close();
                }
            }

            return aux;
        }

        public int ProximaReceta()
        {
            int prox = 0;
            SqlCommand cmd = new SqlCommand("SP_PROXIMO_ID", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cnn.Open();
            SqlParameter paramSalida = new SqlParameter();
            paramSalida.ParameterName = "@next";
            paramSalida.SqlDbType = SqlDbType.Int;
            paramSalida.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramSalida);

            cmd.ExecuteNonQuery();
            cnn.Close();

            prox = (int)paramSalida.Value;

            return prox;
        }

    }
}
