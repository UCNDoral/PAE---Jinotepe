using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CNClientes
    {
        private CDClientes datos = new CDClientes();

        public DataTable MostrarClientes()
        {
            return datos.Mostrar();
        } 

        public void InsertarCliente(string nombre, string apellido, string telefono, string direccion)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es obligatorio.");
            datos.Insertar(nombre, apellido, telefono, direccion);
        }

        public void ActualizarCliente(int id, string nombre, string apellido, string telefono, string direccion)
        {
            if (id <= 0) throw new ArgumentException("ID inválido.");
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es obligatorio.");
            datos.Actualizar(id, nombre, apellido, telefono, direccion);
        }

        public void EliminarCliente(int id)
        {
            if (id <= 0) throw new ArgumentException("ID inválido.");
            datos.Eliminar(id);
        }
    }
}
