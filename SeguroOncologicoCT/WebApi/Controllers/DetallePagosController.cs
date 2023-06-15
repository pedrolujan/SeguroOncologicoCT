using Datos;
using Microsoft.AspNetCore.Mvc;
using ServiciosInternos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("detallePagos")]
    public class DetallePagosController:ControllerBase
    {
        SIDetallePagos ExSp;
        ResponseData Resp;

        [HttpPost]
        [Route("guardar-detallePagos")]
        public dynamic GuardarDetallePagos(DetallePagos clsDetallePagos)
        {
            ExSp = new SIDetallePagos();
            Int32 numRows = 0;
            numRows = ExSp.GuardarDetallePagos(clsDetallePagos);
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
        [Route("listar-detallePagos")]
        public dynamic ListarDetallePagos(int idDetallePagos)
        {
            ExSp = new SIDetallePagos();
            List<DetallePagos> lstDetallePagos = new List<DetallePagos>();
            lstDetallePagos = ExSp.ListarDetallePagos(idDetallePagos);
            Resp = new ResponseData
            {
                state = true,
                message = "Result success",
                result = lstDetallePagos

            };

            return Resp;

        }
    }
}
