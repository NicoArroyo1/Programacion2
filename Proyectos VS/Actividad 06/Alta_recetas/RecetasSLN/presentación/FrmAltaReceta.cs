using RecetasSLN.datos;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN
{
    public partial class FrmAltaReceta : Form
    {
        private Helper Helper;

        private Receta receta;

        public FrmAltaReceta()
        {
            InitializeComponent();
            receta = new Receta();
        }

        private void FrmAltaReceta_Load(object sender, EventArgs e)
        {
            CargarCombo();
            Limpiar();
            lblNro.Text = "Receta # " + Helper.ProximaReceta().ToString();
        }

        #region Metodos de Soporte
        public void CargarCombo()
        {
            Helper = new Helper();
            cboIngrediente.DataSource = Helper.ConsultarSP("SP_CONSULTAR_INGREDIENTES");
            cboIngrediente.ValueMember = "id_ingrediente";
            cboIngrediente.DisplayMember = "n_ingrediente";
            cboIngrediente.SelectedIndex = -1;
        }

        public void Limpiar()
        {
            txtNombre.Text = String.Empty;
            txtCheff.Text = String.Empty;
            cboTipo.SelectedIndex = -1;
            cboIngrediente.SelectedIndex = -1;
            nudCantidad.Value = 1;
            dgvDetalles.Rows.Clear();
            lblTotalIngredientes.Text = "Total de ingredientes:";
        }

        public bool Existe(string item)
        {
            bool aux = false;

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["ingrediente"].Value.ToString().Equals(item))
                {
                    aux = true;
                    break;
                }
            }

            return aux;
        }
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboIngrediente.SelectedIndex != -1)
            {
                //controlo si ya existe
                if (!Existe(cboIngrediente.Text))
                {
                    //agrego el ingrediente al DataGridView
                    Detalle_Receta det = new Detalle_Receta();
                    det.Cantidad = (double)nudCantidad.Value;

                    int id = cboIngrediente.SelectedIndex + 1;
                    string nom = cboIngrediente.Text;
                    string uni = cboIngrediente.ValueMember;

                    det.Ingrediente = new Ingrediente(id, nom, uni);
                    receta.AgregarDetalle(det);

                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(dgvDetalles);
                    fila.Cells[0].Value = det.Ingrediente.Id_ingrediente.ToString();
                    fila.Cells[1].Value = det.Ingrediente.Nombre.ToString();
                    fila.Cells[2].Value = det.Cantidad.ToString();
                    dgvDetalles.Rows.Add(fila);

                    lblTotalIngredientes.Text = "Total de ingredientes: " + dgvDetalles.Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show("Este ingrediente ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboIngrediente.Focus();
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar un ingrediente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboIngrediente.Focus();
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            #region Validaciones varias
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return;
            }
            else if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de receta válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (dgvDetalles.Rows.Count < 3)
            {
                MessageBox.Show("Debe elegir al menos 3 ingredientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            #endregion
            
            DialogResult result = MessageBox.Show("¿Esta seguro de agregar esta receta?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                receta.Nombre = txtNombre.Text;
                receta.Cheff = txtCheff.Text;
                //CUIDADO: Este combo es fijo, no se carga con elementos
                //de la db, entonces podes tomar SelectedIndex + 1 como Id
                //si se carga de la db seria ValueMember
                receta.Tipo_receta = cboTipo.SelectedIndex + 1;

                if (Helper.InsertarMD(receta))
                {
                    MessageBox.Show("Carga Exitosa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    lblNro.Text = "Receta # " + Helper.ProximaReceta().ToString();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                return;
            }
        }

    }
}
