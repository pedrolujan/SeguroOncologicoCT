using Datos;
using Microsoft.AspNetCore.Mvc;
using ServiciosInternos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("tipo-seguro")]
    public class TipoSeguroController:ControllerBase
    {

        SITipoSeguro ExSp;
        ResponseData Resp;

        [HttpGet]
        [Route("listar-tipo-seguro")]
        public dynamic ListarTipoSeguro(int idTipoSeguro)
        {
            ExSp = new SITipoSeguro();
            List<TipoSeguro> lstTipoSeguro = new List<TipoSeguro>();
            lstTipoSeguro = ExSp.ListarTipoSeguro(idTipoSeguro);
            Resp = new ResponseData
            {
                state = true,
                message = "Result success",
                result = lstTipoSeguro

            };

            return Resp;

        }

        [HttpPost]
        [Route("guardar-tipo-seguro")]
        public dynamic GuardarTipoSeguro(TipoSeguro clsTipoSeguro)
        {
            ExSp = new SITipoSeguro();
            Int32 numRows = 0;
            numRows = ExSp.GuardarTipoSeguro(clsTipoSeguro);
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
    }
}
