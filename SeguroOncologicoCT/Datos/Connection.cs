using System.Data.Common;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Datos
{
    public class Connection
    {
        public SqlConnection strConexion;
        private SqlCommand cmdComando;
        //private String lsCadena = "Initial Catalog=Husat; Data Source=365.database.windows.net; User ID=husat;Password=Mihus@t1";
        private String lsCadena = "";
        private int nTimeOut;

        public Connection(int pnTimenOut = 7200)
        {
            lsCadena = @"Initial Catalog=CajaTrujillo; Data Source=DESKTOP-4SH1CJH\SQLEXPRESS; User ID=sa;Password=123456";
            strConexion = new SqlConnection(lsCadena);
            strConexion.Open();
            nTimeOut = pnTimenOut;
        }

     
        public Int32 EjecutarProcedimiento(string storedProcedureName, params object[] parameterValues)
        {

            Int32 nRowsAfec = 0;
            try
            {            
               
                cmdComando = new SqlCommand(storedProcedureName, strConexion);
                cmdComando.CommandTimeout = nTimeOut;
                cmdComando.CommandType = CommandType.StoredProcedure;
                AssignParameterValues(cmdComando, parameterValues);

                nRowsAfec = cmdComando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            return nRowsAfec;
        }

        void AssignParameterValues(DbCommand command, object[] values)
        {
            foreach (IDataParameter parameter in values)
            {
                command.Parameters.Add(parameter);
            }

        }


        public DataSet EjecutarProcedimientoDS(string storedProcedureName, params object[] parameterValues)
        {
            DataSet dsResultado = new DataSet();
            SqlDataAdapter da;
            try
            {
               
                cmdComando = new SqlCommand(storedProcedureName, strConexion);
                cmdComando.CommandTimeout = nTimeOut;
                cmdComando.CommandType = CommandType.StoredProcedure;
                AssignParameterValues(cmdComando, parameterValues);
                da = new SqlDataAdapter(cmdComando);
                da.Fill(dsResultado);
                return dsResultado;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }

        }


        public DataTable EjecutarProcedimientoDT(string storedProcedureName, params object[] parameterValues)
        {
            DataTable dtResultado = new DataTable();
            SqlDataAdapter da;
            try
            {
                
                cmdComando = new SqlCommand(storedProcedureName, strConexion);
                cmdComando.CommandTimeout = nTimeOut;
                cmdComando.CommandType = CommandType.StoredProcedure;
                if (parameterValues != null)
                {
                    AssignParameterValues(cmdComando, parameterValues);
                }

                da = new SqlDataAdapter(cmdComando);
                da.Fill(dtResultado);
                return dtResultado;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }

        }

        public void CierraConexion()
        {
            strConexion.Close();
            strConexion.Dispose();
        }



    }
}