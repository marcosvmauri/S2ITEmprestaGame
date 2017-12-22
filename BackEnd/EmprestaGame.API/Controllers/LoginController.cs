using EmprestaGame.API.Filters;
using EmprestaGame.API.Helpers;
using EmprestaGame.API.Model;
using EmprestaGame.API.ReturnMessage;
using EmprestaGame.Business;
using EmprestaGame.Business.Contracts;
using EmprestaGame.DTO;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmprestaGame.API.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private readonly AuthenticationHelper _authHelper;
        private IBusinessBase<Usuario> _usuarioBusiness;

        public LoginController(AuthenticationHelper authHelper, IBusinessBase<Usuario> usuarioBusiness)
        {
            _authHelper = authHelper;
            _usuarioBusiness = usuarioBusiness;
        }

        [HttpPost]
        [Route("Logar")]
        [AuthEmprestaGame]
        public IHttpActionResult Logar([FromBody]LoginDTO login)
        {
            ModelBase<object> retorno = new ModelBase<object>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = new { Token = _authHelper.GetToken(login.Login) };
            
            return Ok(retorno);
        }

        [HttpPost]
        [Route("Logoff")]
        [AuthEmprestaGame]
        public IHttpActionResult Logoff([FromBody]LoginDTO login)
        {
            _authHelper.RemoverToken(login.Login);

            ModelBase<object> retorno = new ModelBase<object>();
            retorno.Mensagem = SuccessMessages.EXCLUSAO;
            retorno.Model = null;

            return Ok(retorno);
        }
        
    }
}