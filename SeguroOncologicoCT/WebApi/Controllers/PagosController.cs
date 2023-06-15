using Datos;
using Microsoft.AspNetCore.Mvc;
using ServiciosInternos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("pagos")]
    public class PagosController
    {
        SIPagos ExSp;
        ResponseData Resp;

        [HttpPost]
        [Route("guardar-pagos")]
        public dynamic GuardarPagos(Pagos clsPagos)
        {
            ExSp = new SIPagos();
            Int32 numRows = 0;
            numRows = ExSp.GuardarPagos(clsPagos);
            if (numRows > 0)
            {
                Resp = new ResponseData
                {
                    state = true,
                    message = "Result success",
                    result = numRows

                };
            }
            else
            {
                Resp = new ResponseData
                {
                    state = false,
                    message = "Result failed",
                    result = numRows

                };

            }


            return Resp;

        }

        [HttpGet]
        [Route("listar-pagos")]
        public dynamic ListarPagos(int idPagos)
        {
            ExSp = new SIPagos();
            List<Pagos> lstPagos = new List<Pagos>();
            lstPagos = ExSp.ListarPagos(idPagos);
            Resp = new ResponseData
            {
                state = true,
                message = "Result success",
                result = lstPagos

            };

            return Resp;

        }
    }
}
