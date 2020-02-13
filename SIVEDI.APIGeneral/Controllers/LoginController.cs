using SIVEDI.APIGeneral.Models;
using SIVEDI.APIGeneral.ServicioGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIVEDI.APIGeneral.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/Login")]
        public ResponseModel Login(AutLogin login)
        {

            ResponseModel result = null;

            try
            {
                if (login != null)
                {
                    try
                    {
                        ServiceClient servicioGeneral = new ServiceClient();
                        result.Respuesta = servicioGeneral.ingresaAplicativo(login.User, login.Password);

                    }
                    catch (Exception e)
                    {
                        result.Codigo = EnumResponseViewModel.ErrorInterno;
                        result.Mensaje = e.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Codigo = EnumResponseViewModel.ErrorInterno;
                result.Mensaje = ex.Message;
            }
            return result;
        }
    }
}
