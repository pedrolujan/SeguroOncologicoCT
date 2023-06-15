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
    public class SICronogramaPagos
    {

        Connection conn;
        public List<CronogramaPagos> ListarCronogramaPagos(int idCronogramaPagos)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[1];
            List<CronogramaPagos> lstCronogramaPagos = new List<CronogramaPagos>();
            DataTable dtResult = new DataTable();
            try
            {
                pa[0] = new SqlParameter("@IdCronogramaPagos", SqlDbType.Int) { Value = idCronogramaPagos };
                dtResult = conn.EjecutarProcedimientoDT("spListarCronogramaPagos", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstCronogramaPagos.Add(new CronogramaPagos
                    {
                        //IdCronogramaPagos = Convert.ToInt32(dt["IdCronogramaPagos"]),
                        IdCronogramaPagos=Convert.ToInt32(dt["IdCronograma"].ToString()),
                        IdAfiliacion=Convert.ToInt32(dt["IdAfiliacion"].ToString()),
                        FechaPago= Convert.ToDateTime(dt["FechaPago"].ToString()),
                        FechaVencimiento= Convert.ToDateTime(dt["FechaVencimiento"].ToString()),
                        FechaRegistro= Convert.ToDateTime(dt["FechaRegistro"].ToString()),
                        Estado=dt["Estado"].ToString(),

                    });


                }
                return lstCronogramaPagos;
            }
            catch (Exception)
            {

                throw;
                return lstCronogramaPagos;
            }

        }
        public Int32 GuardarCronogramaPagos(CronogramaPagos clsCronogramaPagos)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[6];
            List<CronogramaPagos> lstCronogramaPagos = new List<CronogramaPagos>();
            Int32 numRows = 0;
            try
            {
                pa[0] = new SqlParameter("@IdCronogramaPagos", SqlDbType.Int) { Value = clsCronogramaPagos.IdCronogramaPagos };
                pa[1] = new SqlParameter("@IdAfiliacion", SqlDbType.Int) { Value = clsCronogramaPagos.IdAfiliacion };
                pa[2] = new SqlParameter("@FechaPago", SqlDbType.DateTime) { Value = clsCronogramaPagos.FechaPago };
                pa[3] = new SqlParameter("@FechaVencimiento", SqlDbType.DateTime) { Value = clsCronogramaPagos.FechaVencimiento };
                pa[4] = new SqlParameter("@FechaRegistro", SqlDbType.DateTime) { Value = clsCronogramaPagos.FechaRegistro };
                pa[5] = new SqlParameter("@Estado", SqlDbType.VarChar,10) { Value = clsCronogramaPagos.Estado };
                numRows = conn.EjecutarProcedimiento("spGuardarCronogramaPagos", pa);

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
