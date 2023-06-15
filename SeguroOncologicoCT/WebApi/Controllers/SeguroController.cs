using Datos;
using Microsoft.AspNetCore.Mvc;
using ServiciosInternos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Seguro")]
    public class SeguroController:ControllerBase
    {
        SISeguros ExSp;
        ResponseData Resp;

        [HttpPost]
        [Route("guardar-seguro")]
        public dynamic GuardarSeguros(Seguros clsSeguros)
        {
            ExSp = new SISeguros();
            Int32 numRows = 0;
            numRows = ExSp.GuardarSeguros(clsSeguros);
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
        [Route("listar-seguro")]
        public dynamic ListarSeguros(int idSeguro)
        {
            ExSp = new SISeguros();
            List<Seguros> lstSeguros = new List<Seguros>();
            lstSeguros = ExSp.ListarSeguro(idSeguro);
            Resp = new ResponseData
            {
                state = true,
                message = "Result success",
                result = lstSeguros

            };

            return Resp;

        }

        
    }
}
