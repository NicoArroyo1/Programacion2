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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void buscarCarreraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar frmBuscar = new Buscar();
            frmBuscar.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void altaCarreraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlta Alta = new frmAlta();
            Alta.ShowDialog();
        }
    }
}