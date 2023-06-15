using Datos;
using Microsoft.AspNetCore.Mvc;
using ServiciosInternos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("documento-pago")]
    public class DocumentoPagoController
    {
        SIDocumentoPago ExSp;
        ResponseData Resp;

        [HttpPost]
        [Route("guardar-documentoPago")]
        public dynamic GuardarDocumentoPago(DocumentoPago clsDocumentoPago)
        {
            ExSp = new SIDocumentoPago();
            Int32 numRows = 0;
            numRows = ExSp.GuardarDocumentoPago(clsDocumentoPago);
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
        [Route("listar-documentoPago")]
        public dynamic ListarDocumentoPago(int idDocumentoPago)
        {
            ExSp = new SIDocumentoPago();
            List<DocumentoPago> lstDocumentoPago = new List<DocumentoPago>();
            lstDocumentoPago = ExSp.ListarDocumentoPago(idDocumentoPago);
            Resp = new ResponseData
            {
                state = true,
                message = "Result success",
                result = lstDocumentoPago

            };

            return Resp;

        }
    }
}
