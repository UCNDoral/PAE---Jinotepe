using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_HistorialFactura
    {
        private readonly CD_HistorialFactura objetoCD = new CD_HistorialFactura();

        public DataTable ListarHistorial()
        {
            return objetoCD.ObtenerHistorial();
        }

        public DataTable ObtenerDetalles(int idFactura)
        {
            if (idFactura <= 0)
                throw new ArgumentException("ID de factura inválido.");
            return objetoCD.ObtenerDetalles(idFactura);
        }
    }
}
