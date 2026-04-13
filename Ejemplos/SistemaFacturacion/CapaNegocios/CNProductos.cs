using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocios
{
    public class CNProductos
    {
        private CDProductos datos = new CDProductos();

        public DataTable MostrarProducto()
        {
            return datos.Mostrar();
        }

        public void InsertarProducto(string nombre, decimal precio, int stock)
        {
            //Validaciones de negocio antes de tocar la BD
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es obligatorio.");
            if (precio <= 0) throw new ArgumentException("El precio debe ser mayor a 0.");
            if (stock < 0) throw new ArgumentException("El stock no puede ser negativo.");

            datos.Insertar(nombre, precio, stock);
        }

        public void ActualizarProducto(int id, string nombre, decimal precio, int stock)
        {
            if (id <= 0) throw new ArgumentException("ID inválido.");
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es obligatorio.");
            if (precio <= 0) throw new ArgumentException("El precio debe ser mayor a 0.");
            datos.Actualizar(id, nombre, precio, stock);
        }

        public void EliminarProducto(int id)
        {
            if (id <= 0) throw new ArgumentException("ID inválido.");
            datos.Eliminar(id);
        }
    }
}
