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
    public partial class frmAlta : Form
    {
        private ConexionDB oConexion;

        public frmAlta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAlta_Load(object sender, EventArgs e)
        {
            CargarCombo();
        }

        private void CargarCombo()
        {
            oConexion = new ConexionDB();
            cbAsignatura.DataSource = oConexion.SPConsulta("sp_asignaturas");
            cbAsignatura.ValueMember = "Codigo";
            cbAsignatura.DisplayMember = "Materia";
            cbAsignatura.SelectedIndex = -1;
        }

        private void cbAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAsignatura.SelectedIndex == -1)
            {
                btnAgregar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = true;
            }
        }

        private void txtCarrera_TextChanged(object sender, EventArgs e)
        {
            if(txtCarrera.Text == String.Empty)
            {
                cbAsignatura.Enabled = false;
            }
        }

        private void ValidarCarga()
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = new DataGridViewRow();
            fila.CreateCells(dgvMaterias);
            fila.Cells[0].Value = cbAsignatura.SelectedIndex + 1;
            fila.Cells[1].Value = cbAsignatura.Text;
            dgvMaterias.Rows.Add(fila);

            cbAsignatura.SelectedIndex = -1;

            //falta recorrer el data grid para validar
            //q no cargue 2 veces la misma materia
        }
    }
}
