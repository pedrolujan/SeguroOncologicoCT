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
    public class SISeguros
    {
        Connection conn;
        public List<Seguros> ListarSeguro(int idSeguro)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[1];
            List<Seguros> lstCliente = new List<Seguros>();
            DataTable dtResult = new DataTable();
            try
            {
                pa[0] = new SqlParameter("@IdSeguro", SqlDbType.Int) { Value = idSeguro };
                dtResult = conn.EjecutarProcedimientoDT("spListarSeguro", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstCliente.Add(new Seguros
                    {

                        IdSeguro= Convert.ToInt32(dt["IdSeguro"].ToString()),
                        NombreCompania =dt["NombreCompania"].ToString(),
                        IdTipoSeguro= Convert.ToInt32(dt["IdTipoSeguro"].ToString()),
                        FactorImpuesto=Convert.ToDecimal(dt["FactorImpuesto"].ToString()),
                        PrecioUnitario=Convert.ToDecimal(dt["PrecioUnitario"].ToString()),
                        PorcentajeComision=Convert.ToDecimal(dt["PorcentajeComision"].ToString()),
                        ImporteMensual=Convert.ToDecimal(dt["ImporteMensual"].ToString()),
                        FechaVigencia= Convert.ToDateTime(dt["FechaVigencia"].ToString()),
                        EdadPermitida= Convert.ToInt32(dt["EdadPermitida"].ToString()),
                        Estado=dt["Estado"].ToString()

                    });


                }
                return lstCliente;
            }
            catch (Exception)
            {

                throw;
                return lstCliente;
            }

        }
        public Int32 GuardarSeguros(Seguros clsSeguros)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[10];
            List<Cliente> lstCliente = new List<Cliente>();
            Int32 numRows = 0;
            try
            {
                pa[0] = new SqlParameter("@IdSeguro", SqlDbType.Int) { Value = clsSeguros.IdSeguro };
                pa[1] = new SqlParameter("@NombreCompania", SqlDbType.VarChar, 100) { Value = clsSeguros.NombreCompania };
                pa[2] = new SqlParameter("@IdTipoSeguro", SqlDbType.Int) { Value = clsSeguros.IdTipoSeguro };
                pa[3] = new SqlParameter("@FactorImpuesto", SqlDbType.Money) { Value = clsSeguros.FactorImpuesto };
                pa[4] = new SqlParameter("@PrecioUnitario", SqlDbType.Money) { Value = clsSeguros.PrecioUnitario };
                pa[5] = new SqlParameter("@PorcentajeComision", SqlDbType.Money) { Value = clsSeguros.PorcentajeComision };
                pa[6] = new SqlParameter("@ImporteMensual", SqlDbType.Money) { Value = clsSeguros.ImporteMensual };
                pa[7] = new SqlParameter("@FechaVigencia", SqlDbType.DateTime) { Value = clsSeguros.FechaVigencia };
                pa[8] = new SqlParameter("@EdadPermitida", SqlDbType.Int) { Value = clsSeguros.EdadPermitida };
                pa[9] = new SqlParameter("@Estado", SqlDbType.VarChar, 10) { Value = clsSeguros.Estado };

                numRows = conn.EjecutarProcedimiento("spGuardarSeguro", pa);

                return numRows;
            }
            catch (Exception)
            {

                throw;
                return numRows;
            }
            finally
            {
                conn.CierraConexion();
            }

        }
    }
}
