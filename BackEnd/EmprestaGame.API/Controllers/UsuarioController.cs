using EmprestaGame.API.Filters;
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
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : BaseController
    {
        
        //private readonly AuthenticationHelper _authHelper;
        private IBusinessBase<Usuario> _usuarioBusiness;

        public UsuarioController(IBusinessBase<Usuario> businessBase)
        {
            //_authHelper = authHelper;
            _usuarioBusiness = businessBase;
        }

        [HttpGet]
        [Route("Get")]
        [AuthEmprestaGame]
        public IHttpActionResult Get()
        {
            var listaUsuario = _usuarioBusiness.GetAll();

            var retorno = new ModelBase<List<UsuarioDTO>>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = listaUsuario;

            return Ok(retorno);
        }

        [HttpPost]
        [Route("GetAllUsers")]
        [AuthEmprestaGame]
        public IHttpActionResult GetAllUsers()
        {
            var listaUsuario = _usuarioBusiness.GetAll();

            var retorno = new ModelBase<List<UsuarioDTO>>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = listaUsuario;

            return Ok(retorno);
        }


        [HttpGet]
        [Route("GetItem")]
        [AuthEmprestaGame]
        public IHttpActionResult GetItem([FromUri]int id)
        {
            var usuario = _usuarioBusiness.GetItem(id);

            var retorno = new ModelBase<UsuarioDTO>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = usuario;

            return Ok(retorno);
        }

        [HttpPost]
        [Route("GetByLogin")]
        [AuthEmprestaGame]
        public IHttpActionResult GetByLogin([FromBody]LoginDTO login)
        {
            
            var usuario = _usuarioBusiness.GetItens(x => x.Login == login.Login).Single();
            
            var retorno = new ModelBase<UsuarioDTO>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = usuario;

            return Ok(retorno);
        }


        [HttpPost]
        [Route("Add")]
        [AuthEmprestaGame]
        public IHttpActionResult Add(UsuarioDTO usuarioDTO)
        {
            var usuario = usuarioDTO.ToEntity<Usuario>();
            
            _usuarioBusiness.Add(usuario);

            var retorno = new ModelBase<UsuarioDTO>();
            retorno.Mensagem = SuccessMessages.CADASTRO;

            return Ok(retorno);
        }


        [HttpPut]
        [Route("Update")]
        [AuthEmprestaGame]
        public IHttpActionResult Update(UsuarioDTO usuarioDTO)
        {
            var usuario = _usuarioBusiness.GetItem(usuarioDTO.Id);

            var usuarioAlterado = usuarioDTO.ToEntity<Usuario>();
            usuarioAlterado.Senha = usuario.Senha;

            _usuarioBusiness.Update(usuarioAlterado);

            var retorno = new ModelBase<UsuarioDTO>();
            retorno.Mensagem = SuccessMessages.ALTERACAO;

            return Ok(retorno);
        }


        [HttpPost]
        [Route("Remove")]
        [AuthEmprestaGame]
        public IHttpActionResult Remove([FromBody]UsuarioDTO usuarioDTO)
        {
            var usuario = _usuarioBusiness.GetItem(usuarioDTO.Id);

            usuario.Status = 0;

            _usuarioBusiness.Remove(usuario.Id);

            var retorno = new ModelBase<UsuarioDTO>();
            retorno.Mensagem = SuccessMessages.EXCLUSAO;

            return Ok(retorno);
        }

       
       
    }
}