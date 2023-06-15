using Datos;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography;

namespace ServiciosInternos
{
    public class SICliente
    {
        Connection conn;
        public List<Cliente> ListarCliente(int idCliente)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[1];
            List<Cliente> lstCliente = new List<Cliente>();
            DataTable dtResult = new DataTable();
            try
            {
                pa[0] = new SqlParameter("@idCliente", SqlDbType.Int) { Value = idCliente };
                dtResult=conn.EjecutarProcedimientoDT("spListarCliente", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstCliente.Add(new Cliente
                    {
                        //Id = Convert.ToInt32(dt["idCliente"]),
                        IdCliente= Convert.ToInt32(dt["IdCliente"].ToString()),
                        Dni=dt["Dni"].ToString(),
                        Nombres=dt["Nombres"].ToString(),
                        Apellidos=dt["Aplellidos"].ToString(),
                        Edad=Convert.ToInt32(dt["Edad"].ToString()),
                        Direccion=dt["Direccion"].ToString(),
                        Telefono=dt["Telefono"].ToString()

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
        public Int32 GuardarCliente(Cliente clsCliente)
        {
            conn = new Connection();
            SqlParameter[] pa = new SqlParameter[7];
            List<Cliente> lstCliente = new List<Cliente>();
            Int32 numRows = 0;
            try
            {
                pa[0] = new SqlParameter("@IdCliente", SqlDbType.Int) { Value = clsCliente.IdCliente };
                pa[1] = new SqlParameter("@Dni", SqlDbType.Char) { Value = clsCliente.Dni };
                pa[2] = new SqlParameter("@Nombres", SqlDbType.VarChar,50) { Value = clsCliente.Nombres };
                pa[3] = new SqlParameter("@Apellidos", SqlDbType.VarChar,100) { Value = clsCliente.Apellidos };
                pa[4] = new SqlParameter("@Edad", SqlDbType.Int) { Value = clsCliente.Edad };
                pa[5] = new SqlParameter("@Direccion", SqlDbType.VarChar,500) { Value = clsCliente.Direccion };
                pa[6] = new SqlParameter("@Telefono", SqlDbType.VarChar,12) { Value = clsCliente.Telefono };
                numRows = conn.EjecutarProcedimiento("spGuardarCliente", pa);
                
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