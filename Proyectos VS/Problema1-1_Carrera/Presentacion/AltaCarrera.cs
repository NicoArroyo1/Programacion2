using Problema1_1_Carrera.Datos;
using Problema1_1_Carrera.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
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
            cbAsignatura.Enabled = false;
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
            if(txtCarrera.Text.Length.Equals(0))
            {
                cbAsignatura.Enabled = false;
                btnAgregar.Enabled = false;
            }
            else
            {
                cbAsignatura.Enabled = true;
            }
            
        }

        private bool ValidarCarga()
        {
            if(!txtCarrera.Text.Equals(string.Empty) && dgvMaterias.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GuardarCarrera()
        {
            bool resultado = true;
            
            Carrera carrera = new (txtCarrera.Text);
            carrera.IdCarrera = oConexion.InsertarCarrera(carrera.Nombre, dgvMaterias);
            if(carrera.IdCarrera == -1)
            {
                resultado = false;
            }
            return resultado;
        }

        private void Limpiar()
        {
            txtCarrera.Text = String.Empty;
            cbAsignatura.SelectedIndex = -1;
            dgvMaterias.Rows.Clear();
            txtCarrera.Enabled = true;
            cbAño.SelectedIndex = -1;
            rbtPrimCuat.Checked = false;
            rbtSegCuat.Checked = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
            {
                MessageBox.Show("Datos invalidos","Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (GuardarCarrera() is false)
                {
                    MessageBox.Show("Error al insertar la carrera", "Carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se cargo exitosamente!", "Carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cbAño.SelectedIndex == -1 || (!rbtPrimCuat.Checked && !rbtSegCuat.Checked))
            {
                MessageBox.Show("Faltan Datos!","Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbAsignatura.SelectedIndex = -1;
                cbAño.SelectedIndex = -1;
                rbtPrimCuat.Checked = false;
                rbtSegCuat.Checked = false;
                return;
            }

            DataGridViewRow fila = new DataGridViewRow();
            fila.CreateCells(dgvMaterias);
            fila.Cells[0].Value = cbAsignatura.SelectedIndex + 1;
            fila.Cells[1].Value = cbAsignatura.Text;
            fila.Cells[2].Value = cbAño.SelectedIndex + 1;
            if (rbtPrimCuat.Checked)
            {
                fila.Cells[3].Value = 1;
            }
            else
            {
                fila.Cells[3].Value = 2;
            }
            

            if (dgvMaterias.Rows.Count.Equals(0))
            {
                dgvMaterias.Rows.Add(fila);
                txtCarrera.Enabled = false;
            }
            else
            {
                bool existe = false;
                
                foreach (DataGridViewRow row in dgvMaterias.Rows)
                {
                    if (Convert.ToInt16(row.Cells[0].Value) == Convert.ToInt16(fila.Cells[0].Value))
                    {
                        MessageBox.Show("Esta materia ya existe, seleccione otra.");
                        existe = true;
                        break;
                    }
                    else { existe = false; }

                }
                if (existe is false)
                {
                    dgvMaterias.Rows.Add(fila);
                }
            }

            cbAsignatura.SelectedIndex = -1;
            cbAño.SelectedIndex = -1;
            rbtPrimCuat.Checked = false;
            rbtSegCuat.Checked = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtCarrera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }
    }
}
