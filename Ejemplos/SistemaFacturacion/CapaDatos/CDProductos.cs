using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDProductos
    {
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();

            //'using' garantiza Dispose() automático (cierra conexión y libera memoria)
            using (SqlConnection conn = new CD_Conexion().ObtenerConexion())

            using (SqlCommand comando = new SqlCommand("SELECT IdProducto, Nombre, Precio, Stock FROM Productos WHERE  ACTIVO = 1", conn))
            {
                conn.Open();
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    tabla.Load(reader);
                }
            }
            return tabla;
        }

        public void Insertar(string nombre, decimal precio, int stock)
        {
            using (SqlConnection conn = new CD_Conexion().ObtenerConexion())
            using (SqlCommand comando = new SqlCommand("INSERT INTO Productos (Nombre, Precio, Stock) VALUES (@Nombre, @Precio, @Stock)", conn))
            {
                // Tipos explícitos en parámetros (evita conversiones lentas y errores)
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = nombre;
         
                comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = precio;
                comando.Parameters.Add("@Stock", SqlDbType.Int).Value = stock;

                conn.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void Actualizar(int id, string nombre, decimal precio, int stock)
        {
            using (SqlConnection conn = new CD_Conexion().ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock WHERE IdProducto = @Id", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = nombre;
                cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = precio;
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = stock;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Borrado lógico(Activo = 0)
        public void Eliminar(int id)
        {
            using (SqlConnection conn = new CD_Conexion().ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("UPDATE Productos SET Activo = 0 WHERE IdProducto = @Id", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }




    }
}
