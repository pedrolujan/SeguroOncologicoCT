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
    public class SITipoSeguro
    {

        Connection conn;
        public List<TipoSeguro> ListarTipoSeguro(int idTipoSeguro)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[1];
            List<TipoSeguro> lstCliente = new List<TipoSeguro>();
            DataTable dtResult = new DataTable();
            try
            {
                pa[0] = new SqlParameter("@IdTipoSeguro", SqlDbType.Int) { Value = idTipoSeguro };
                dtResult = conn.EjecutarProcedimientoDT("spListarTipoSeguro", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstCliente.Add(new TipoSeguro
                    {
                        //IdTipoSeguro = Convert.ToInt32(dt["idCliente"]),
                        IdTipoSeguro= Convert.ToInt32(dt["IdTipoSeguro"].ToString()),
                        Nombre=dt["Nombre"].ToString(),
                        FechaRegistro= Convert.ToDateTime(dt["FechaRegistro"].ToString()),
                        Estado=dt["Estado"].ToString(),

                    });


                }
                return lstCliente;
            }
            catch (Exception)
            {
                conn.CierraConexion();

                throw;
                return lstCliente;
            }
            finally
            {
                conn.CierraConexion();
            }

        }
        public Int32 GuardarTipoSeguro(TipoSeguro clsTipoSeguro)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[4];
            List<Cliente> lstCliente = new List<Cliente>();
            Int32 numRows = 0;
            try
            {
                pa[0] = new SqlParameter("@IdTipoSeguro", SqlDbType.Int) { Value = clsTipoSeguro.IdTipoSeguro };
                pa[1] = new SqlParameter("@Nombre", SqlDbType.VarChar,100) { Value = clsTipoSeguro.Nombre };
                pa[2] = new SqlParameter("@FechaRegistro", SqlDbType.DateTime) { Value = clsTipoSeguro.FechaRegistro };
                pa[3] = new SqlParameter("@Estado", SqlDbType.VarChar, 10) { Value = clsTipoSeguro.Estado };

                numRows = conn.EjecutarProcedimiento("spGuardarTipoSeguro", pa);

                return numRows;
            }
            catch (Exception)
            {
                conn.CierraConexion();
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
