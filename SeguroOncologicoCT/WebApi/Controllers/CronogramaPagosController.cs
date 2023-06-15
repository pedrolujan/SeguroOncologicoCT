using Datos;
using Microsoft.AspNetCore.Mvc;
using ServiciosInternos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("cronograma-pagos")]
    public class CronogramaPagosController
    {
        SICronogramaPagos ExSp;
        ResponseData Resp;

        [HttpPost]
        [Route("guardar-cronogramaPagos")]
        public dynamic GuardarCronogramaPagos(CronogramaPagos clsCronogramaPagos)
        {
            ExSp = new SICronogramaPagos();
            Int32 numRows = 0;
            numRows = ExSp.GuardarCronogramaPagos(clsCronogramaPagos);
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
        [Route("listar-CronogramaPagos")]
        public dynamic ListarCronogramaPagos(int idCronogramaPagos)
        {
            ExSp = new SICronogramaPagos();
            List<CronogramaPagos> lstCronogramaPagos = new List<CronogramaPagos>();
            lstCronogramaPagos = ExSp.ListarCronogramaPagos(idCronogramaPagos);
            Resp = new ResponseData
            {
                state = true,
                message = "Result success",
                result = lstCronogramaPagos

            };

            return Resp;

        }
    }
}
