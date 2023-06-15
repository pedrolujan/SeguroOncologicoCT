using Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosInternos
{
    public class SIDetallePagos
    {

        Connection conn;
        public List<DetallePagos> ListarDetallePagos(int idDetallePagos)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[1];
            List<DetallePagos> lstDetallePagos = new List<DetallePagos>();
            DataTable dtResult = new DataTable();
            try
            {
                pa[0] = new SqlParameter("@IdDetallePagos", SqlDbType.Int) { Value = idDetallePagos };
                dtResult = conn.EjecutarProcedimientoDT("spListarDetalloPago", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstDetallePagos.Add(new DetallePagos
                    {
                        //IdDetallePagos = Convert.ToInt32(dt["IdDetallePagos"]),
                        IdDetallePagos= Convert.ToInt32(dt["IdPagos"].ToString()),
                        IdPagos=Convert.ToInt32(dt["IdPagos"].ToString()),
                        FechaRegistro= Convert.ToDateTime(dt["FechaRegistro"].ToString()),
                        Observaciones=dt["Observaciones"].ToString(),
                        estado=dt["estado"].ToString(),

                    });


                }
                return lstDetallePagos;
            }
            catch (Exception)
            {

                throw;
                return lstDetallePagos;
            }

        }
        public Int32 GuardarDetallePagos(DetallePagos clsDetallePagos)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[5];
            List<DetallePagos> lstDetallePagos = new List<DetallePagos>();
            Int32 numRows = 0;
            try
            {
                pa[0] = new SqlParameter("@IdDetallePagos", SqlDbType.Int) { Value = clsDetallePagos.IdDetallePagos };
                pa[1] = new SqlParameter("@IdPagos", SqlDbType.Int) { Value = clsDetallePagos.IdPagos };
                pa[2] = new SqlParameter("@FechaRegistro", SqlDbType.DateTime) { Value = clsDetallePagos.FechaRegistro };
                pa[3] = new SqlParameter("@Observaciones", SqlDbType.NVarChar,100) { Value = clsDetallePagos.Observaciones };
                pa[4] = new SqlParameter("@estado", SqlDbType.NVarChar,10) { Value = clsDetallePagos.estado };

                numRows = conn.EjecutarProcedimiento("spGuardarDetalloPago", pa);

                return numRows;
            }
            catch (Exception)
            {

                throw;
                return numRows;
            }

        }
    }
}
