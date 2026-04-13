using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFacturacion formFacturacion = new FormFacturacion();
            formFacturacion.ShowDialog();
        }

        private void historialDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHistorialFacturas formHistorialFact = new FormHistorialFacturas();
            formHistorialFact.ShowDialog();
        }
    }
}
