using EmprestaGame.API.Model;
using EmprestaGame.API.ReturnMessage;
using EmprestaGame.Business;
using EmprestaGame.Business.Contracts;
using EmprestaGame.DTO;
using Entities;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using EmprestaGame.API.Filters;

namespace EmprestaGame.API.Controllers
{
    [RoutePrefix("api/Jogo")]
    public class JogoController : BaseController
    {

        //private readonly AuthenticationHelper _authHelper;
        private IJogoBusiness _jogoBusiness;
        private IBusinessBase<Usuario> _usuarioBusiness;
        private IBusinessBase<Emprestimo> _emprestimoBusiness;

        public JogoController(IJogoBusiness jogoBusiness, IBusinessBase<Usuario> usuarioBusiness, IBusinessBase<Emprestimo> emprestimoBusiness)
        {
            //_authHelper = authHelper;
            _jogoBusiness = jogoBusiness;
            _usuarioBusiness = usuarioBusiness;
            _emprestimoBusiness = emprestimoBusiness;
        }

        [HttpGet]
        [Route("Get")]
        [AuthEmprestaGame]
        public IHttpActionResult Get()
        {
            var listaJogo = _jogoBusiness.GetAll();

            var retorno = new ModelBase<List<JogoDTO>>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = listaJogo;

            return Ok(retorno);
        }


        [HttpGet]
        [Route("GetItem")]
        [AuthEmprestaGame]
        public IHttpActionResult GetItem([FromUri]int id)
        {
            var jogo = _jogoBusiness.GetItem(id);

            var retorno = new ModelBase<JogoDTO>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = jogo;

            return Ok(retorno);
        }

        [HttpGet]
        [Route("MeusJogos")]
        [AuthEmprestaGame]
        public IHttpActionResult MeusJogos()
        {
            var login = GetUsuarioLogado();

            var listaJogos = _jogoBusiness.MeusJogos(login);

            var retorno = new ModelBase<List<JogoUsuarioDTO>>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = listaJogos;

            return Ok(retorno);
        }


        [HttpGet]
        [Route("JogosDisponiveis")]
        [AuthEmprestaGame]
        public IHttpActionResult JogosDisponiveis()
        {
            var login = GetUsuarioLogado();

            var listaJogos = _jogoBusiness.JogosDisponiveis(login);

            var retorno = new ModelBase<List<JogoDTO>>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = listaJogos;

            return Ok(retorno);
        }

        [HttpGet]
        [Route("JogosEmprestados")]
        [AuthEmprestaGame]
        public IHttpActionResult JogosEmprestados()
        {
            var login = GetUsuarioLogado();

            var listaJogos = _jogoBusiness.JogosEmprestados(login);

            var retorno = new ModelBase<List<JogoDTO>>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = listaJogos;

            return Ok(retorno);
        }

        [HttpGet]
        [Route("JogosAdevolver")]
        [AuthEmprestaGame]
        public IHttpActionResult JogosAdevolver()
        {
            var login = GetUsuarioLogado();

            var listaJogos = _jogoBusiness.JogosAdevolver(login);

            var retorno = new ModelBase<List<JogoDTO>>();
            retorno.Mensagem = SuccessMessages.CONSULTA;
            retorno.Model = listaJogos;

            return Ok(retorno);
        }

        [HttpPost]
        [Route("Add")]
        [AuthEmprestaGame]
        public IHttpActionResult Add(JogoDTO jogoDTO)
        {
            var login = GetUsuarioLogado();

            var usuario = _usuarioBusiness.GetItens(x => x.Login == login).FirstOrDefault();

            jogoDTO.idUsuario = usuario.Id;

            var jogo = jogoDTO.ToEntity<Jogo>();

            _jogoBusiness.Add(jogo);

            var retorno = new ModelBase<JogoDTO>();
            retorno.Mensagem = SuccessMessages.CADASTRO;

            return Ok(retorno);
        }


        [HttpPut]
        [Route("Update")]
        [AuthEmprestaGame]
        public IHttpActionResult Update(JogoDTO jogoDTO)
        {
            var jogo = _jogoBusiness.GetItem(jogoDTO.Id);

            var jogoAlterado = jogoDTO.ToEntity<Jogo>();

            _jogoBusiness.Update(jogoAlterado);

            var retorno = new ModelBase<JogoDTO>();
            retorno.Mensagem = SuccessMessages.ALTERACAO;

            return Ok(retorno);
        }


        [HttpPost]
        [Route("Remove")]
        [AuthEmprestaGame]
        public IHttpActionResult Remove([FromBody]JogoDTO jogo)
        {
            _jogoBusiness.Remove(jogo.Id);

            var retorno = new ModelBase<JogoDTO>();
            retorno.Mensagem = SuccessMessages.EXCLUSAO;

            return Ok(retorno);
        }

        [HttpPost]
        [Route("EmprestarJogo")]
        [AuthEmprestaGame]
        public IHttpActionResult EmprestarJogo([FromBody]JogoDTO jogoDTO)
        {
            var login = GetUsuarioLogado();

            var usuario = _usuarioBusiness.GetItens(x => x.Login == login).FirstOrDefault();

            var emprestimo = new Emprestimo()
            {
                idJogo = jogoDTO.Id,
                idUsuario = usuario.Id,
                Status = 1
            };

            _emprestimoBusiness.Add(emprestimo);

            var retorno = new ModelBase<JogoDTO>();
            retorno.Mensagem = SuccessMessages.CADASTRO;

            return Ok(retorno);
        }

        [HttpPost]
        [Route("DevolverJogo")]
        [AuthEmprestaGame]
        public IHttpActionResult DevolverJogo([FromBody]JogoDTO jogoDTO)
        {

            var login = GetUsuarioLogado();

            var usuario = _usuarioBusiness.GetItens(x => x.Login == login).FirstOrDefault();

            var emprestimo = _emprestimoBusiness.GetItens(x => x.idJogo == jogoDTO.Id && x.idUsuario == usuario.Id && x.Status == 1).FirstOrDefault();

            emprestimo.Status = 0;

            _emprestimoBusiness.Update(emprestimo);

            var retorno = new ModelBase<JogoDTO>();
            retorno.Mensagem = SuccessMessages.DEVOLVIDO;

            return Ok(retorno);
        }



    }
}