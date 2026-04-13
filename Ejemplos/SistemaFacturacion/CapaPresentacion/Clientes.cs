using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FrmClientes : Form
    {
        private  CNClientes negocio = new CNClientes();
        private int idSeleccionado = 0;
        private bool editando = false;

        public FrmClientes()
        {
            InitializeComponent();
        }


        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }
        private void CargarGrid()
        {
            dgvClientes.DataSource = negocio.MostrarClientes();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvClientes.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(row.Cells["IdCliente"].Value);
                txtId.Text = row.Cells["IdCliente"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtDireccio.Text = row.Cells["Direccion"].Value.ToString();
                editando = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                if (editando)
                    negocio.ActualizarCliente(idSeleccionado, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccio.Text);
                else
                    negocio.InsertarCliente(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccio.Text);

                MessageBox.Show(editando ? "✅ Actualizado." : "✅ Registrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarGrid();
            }
            catch (Exception ex) { MessageBox.Show($"❌ Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            if (MessageBox.Show("¿Eliminar cliente?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                negocio.EliminarCliente(idSeleccionado);
                MessageBox.Show("Cliente eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarGrid();
            }
        }

        private void Limpiar()
        {
            txtId.Clear(); txtNombre.Clear(); txtApellido.Clear(); txtTelefono.Clear(); txtDireccio.Clear();
            idSeleccionado = 0; editando = false; txtNombre.Focus();
        }
    }
}
