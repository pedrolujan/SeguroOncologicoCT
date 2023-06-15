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
    public class SIAfiliacion
    {
        Connection conn;
        public List<Afiliacion> ListarAfiliacion(int idAfiliacion)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[1];
            List<Afiliacion> lstAfiliacion = new List<Afiliacion>();
            DataTable dtResult = new DataTable();
            try
            {
                pa[0] = new SqlParameter("@IdAfiliacion", SqlDbType.Int) { Value = idAfiliacion };
                dtResult = conn.EjecutarProcedimientoDT("spListarAfiliacion", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstAfiliacion.Add(new Afiliacion
                    {
                        //IdAfiliacion = Convert.ToInt32(dt["IdAfiliacion"]),

                        IdAfiliacion= Convert.ToInt32(dt["IdAfiliacion"].ToString()),
                        FechaInicio= Convert.ToDateTime(dt["FechaInicio"].ToString()),
                        FechaFin= Convert.ToDateTime(dt["FechaFin"].ToString()),
                        FechaRegistro=Convert.ToDateTime(dt["FechaRegistro"].ToString()),
                        IdCliente= Convert.ToInt32(dt["IdCliente"].ToString()),
                        IdSeguro= Convert.ToInt32(dt["IdSeguro"].ToString()),
                        Estado=dt["Estado"].ToString(),


                    });


                }
                return lstAfiliacion;
            }
            catch (Exception)
            {

                throw;
                return lstAfiliacion;
            }

        }
        public Int32 GuardarAfiliacion(Afiliacion clsAfiliacion)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[7];
            List<Afiliacion> lstAfiliacion = new List<Afiliacion>();
            Int32 numRows = 0;
            try
            {
                pa[0] = new SqlParameter("@IdAfiliacion", SqlDbType.Int) { Value = clsAfiliacion.IdAfiliacion };
                pa[1] = new SqlParameter("@FechaInicio", SqlDbType.DateTime) { Value = clsAfiliacion.FechaInicio };
                pa[2] = new SqlParameter("@FechaFin", SqlDbType.DateTime) { Value = clsAfiliacion.FechaFin };
                pa[3] = new SqlParameter("@FechaRegistro", SqlDbType.DateTime) { Value = clsAfiliacion.FechaRegistro };
                pa[4] = new SqlParameter("@IdCliente", SqlDbType.Int) { Value = clsAfiliacion.IdCliente };
                pa[5] = new SqlParameter("@IdSeguro", SqlDbType.Int) { Value = clsAfiliacion.IdSeguro };
                pa[6] = new SqlParameter("@Estado", SqlDbType.VarChar, 10) { Value = clsAfiliacion.Estado };
                numRows = conn.EjecutarProcedimiento("spGuardarAfiliacion", pa);

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
