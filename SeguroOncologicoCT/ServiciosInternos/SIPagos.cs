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
    public class SIPagos
    {

        Connection conn;
        public List<Pagos> ListarPagos(int idPagos)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[1];
            List<Pagos> lstPagos = new List<Pagos>();
            DataTable dtResult = new DataTable();
            try
            {
                pa[0] = new SqlParameter("@IdPagos", SqlDbType.Int) { Value = idPagos };
                dtResult = conn.EjecutarProcedimientoDT("spListarPago", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstPagos.Add(new Pagos
                    {
                        //IdPagos = Convert.ToInt32(dt["IdPagos"]),
                        IdPagos= Convert.ToInt32(dt["IdPago"].ToString()),
                        IdCronograma=Convert.ToInt32(dt["IdCronograma"].ToString()),
                        FechaPago= Convert.ToDateTime(dt["FechaPago"].ToString()),
                        IdMoneda=Convert.ToInt32(dt["IdMoneda"].ToString()),
                        Importe=Convert.ToDecimal(dt["Importe"].ToString()),
                        Estado=dt["Estado"].ToString(),

                    });


                }
                return lstPagos;
            }
            catch (Exception)
            {

                throw;
                return lstPagos;
            }

        }
        public Int32 GuardarPagos(Pagos clsPagos)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[6];
            List<Pagos> lstPagos = new List<Pagos>();
            Int32 numRows = 0;
            try
            {
                pa[0] = new SqlParameter("@IdPagos", SqlDbType.Int) { Value = clsPagos.IdPagos };
                pa[1] = new SqlParameter("@IdCronograma", SqlDbType.Int) { Value = clsPagos.IdCronograma };
                pa[2] = new SqlParameter("@FechaPago", SqlDbType.DateTime) { Value = clsPagos.FechaPago };
                pa[3] = new SqlParameter("@IdMoneda", SqlDbType.Int) { Value = clsPagos.IdMoneda };
                pa[4] = new SqlParameter("@Importe", SqlDbType.Money) { Value = clsPagos.Importe };
                pa[5] = new SqlParameter("@Estado", SqlDbType.VarChar,10) { Value = clsPagos.Estado };

                numRows = conn.EjecutarProcedimiento("spGuardarPago", pa);

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
