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
    public class SIDocumentoPago
    {
        Connection conn;
        public List<DocumentoPago> ListarDocumentoPago(int idDocumentoPago)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[1];
            List<DocumentoPago> lstDocumentoPago = new List<DocumentoPago>();
            DataTable dtResult = new DataTable();
            try
            {
                pa[0] = new SqlParameter("@IdDocumentoPago", SqlDbType.Int) { Value = idDocumentoPago };
                dtResult = conn.EjecutarProcedimientoDT("spListarDocumentoPago", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstDocumentoPago.Add(new DocumentoPago
                    {
                        //IdDocumentoPago = Convert.ToInt32(dt["IdDocumentoPago"]),
                        IdDocumentoPago= Convert.ToInt32(dt["IdDocumentoPago"].ToString()),
                        idPago=Convert.ToInt32(dt["idPago"].ToString()),
                        Codigo=dt["Codigo"].ToString(),
                        ImporteTotal= Convert.ToDecimal(dt["ImporteTotal"].ToString()),
                        Estado=dt["Estado"].ToString(),

                    });


                }
                return lstDocumentoPago;
            }
            catch (Exception)
            {

                throw;
                return lstDocumentoPago;
            }

        }
        public Int32 GuardarDocumentoPago(DocumentoPago clsDocumentoPago)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[5];
            List<DocumentoPago> lstDocumentoPago = new List<DocumentoPago>();
            Int32 numRows = 0;
            try
            {
                pa[0] = new SqlParameter("@IdDocumentoPago", SqlDbType.Int) { Value = clsDocumentoPago.IdDocumentoPago };
                pa[1] = new SqlParameter("@idPago", SqlDbType.Int) { Value = clsDocumentoPago.idPago };
                pa[2] = new SqlParameter("@Codigo", SqlDbType.VarChar,15) { Value = clsDocumentoPago.Codigo };
                pa[3] = new SqlParameter("@ImporteTotal", SqlDbType.Money) { Value = clsDocumentoPago.ImporteTotal };
                pa[4] = new SqlParameter("@Estado", SqlDbType.VarChar,10) { Value = clsDocumentoPago.Estado };

                numRows = conn.EjecutarProcedimiento("spGuardarDocumentoPago", pa);

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
