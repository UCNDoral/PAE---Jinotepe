using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDClientes
    {
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = new CD_Conexion().ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("SELECT IdCliente, Nombre, Apellido, Telefono, Direccion, Activo FROM Clientes WHERE Activo = 1 ORDER BY IdCliente", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) tabla.Load(reader);
            }
            return tabla;
        }

        public void Insertar(string nombre, string apellido, string telefono, string direccion)
        {
            using (SqlConnection conn = new CD_Conexion().ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Clientes (Nombre, Apellido, Telefono, Direccion, Activo) VALUES (@Nombre, @Apellido, @Telefono, @Direccion, 1)", conn))
            {
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = nombre;
                cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(apellido) ? (object)DBNull.Value : apellido;
                cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = string.IsNullOrEmpty(telefono) ? (object)DBNull.Value : telefono;
                cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = string.IsNullOrEmpty(direccion) ? (object)DBNull.Value : direccion;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(int id, string nombre, string apellido, string telefono, string direccion)
        {
            using (SqlConnection conn = new CD_Conexion().ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("UPDATE Clientes SET Nombre=@Nombre, Apellido=@Apellido, Telefono=@Telefono, Direccion=@Direccion, FechaModificacion=GETDATE() WHERE IdCliente=@Id", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = nombre;
                cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(apellido) ? (object)DBNull.Value : apellido;
                cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = string.IsNullOrEmpty(telefono) ? (object)DBNull.Value : telefono;
                cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = string.IsNullOrEmpty(direccion) ? (object)DBNull.Value : direccion;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new CD_Conexion().ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("UPDATE Clientes SET Activo = 0 WHERE IdCliente = @Id", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
