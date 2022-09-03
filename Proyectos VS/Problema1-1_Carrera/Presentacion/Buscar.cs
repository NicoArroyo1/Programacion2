using Problema1_1_Carrera.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problema1_1_Carrera.Presentacion
{
    public partial class Buscar : Form
    {
        private ConexionDB oConexion;

        public Buscar()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            CargarCombo();
        }

        private void CargarCombo()
        {
            oConexion = new ConexionDB();
            cbCarreras.DataSource = oConexion.SPConsulta("sp_carreras");
            cbCarreras.ValueMember = "id_carrera";
            cbCarreras.DisplayMember = "nombre";
            cbCarreras.SelectedIndex = -1;
        }

        private void cbCarreras_SelectedValueChanged(object sender, EventArgs e)
        {
            oConexion = new ConexionDB();
            int carrera = cbCarreras.SelectedIndex + 1;
            DataTable tabla = oConexion.ConsultaMaterias("sp_materias_carrera", carrera);
            dgvAsignaturas.DataSource = tabla;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}