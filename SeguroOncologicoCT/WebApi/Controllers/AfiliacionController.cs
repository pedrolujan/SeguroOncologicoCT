using Datos;
using Microsoft.AspNetCore.Mvc;
using ServiciosInternos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("afiliacion")]
    public class AfiliacionController:ControllerBase
    {
        SIAfiliacion ExSp;
        ResponseData Resp;

        [HttpPost]
        [Route("guardar-afiliacion")]
        public dynamic GuardarAfiliacion(Afiliacion clsAfiliacion)
        {
            ExSp = new SIAfiliacion();
            Int32 numRows = 0;
            numRows = ExSp.GuardarAfiliacion(clsAfiliacion);
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
        [Route("listar-afiliacion")]
        public dynamic ListarAfiliacion(int idAfiliacion)
        {
            ExSp = new SIAfiliacion();
            List<Afiliacion> lstAfiliacion = new List<Afiliacion>();
            lstAfiliacion = ExSp.ListarAfiliacion(idAfiliacion);
            Resp = new ResponseData
            {
                state = true,
                message = "Result success",
                result = lstAfiliacion

            };

            return Resp;

        }
    }
}
