using Datos;
using Microsoft.AspNetCore.Mvc;
using ServiciosInternos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController:ControllerBase
    {
        SICliente ExSp;
        ResponseData Resp;

        [HttpGet]
        [Route("listar-cliente")]
        public dynamic ListarClinete(int idCliente)
        {
            ExSp = new SICliente();
            List<Cliente> lstCliente = new List<Cliente>();
            lstCliente = ExSp.ListarCliente(idCliente);
            Resp = new ResponseData
            {
                state = true,
                message = "Result success",
                result = lstCliente

            };

            return Resp;

        }

        [HttpPost]
        [Route("guardar-cliente")]
        public dynamic GuardarClinete(Cliente clsCliente)
        {
            ExSp = new SICliente();
            Int32 numRows = 0;
            numRows = ExSp.GuardarCliente(clsCliente);
            if (numRows>0)
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
