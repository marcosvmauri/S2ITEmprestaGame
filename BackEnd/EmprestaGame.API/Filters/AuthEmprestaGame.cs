using EmprestaGame.API.Criptography;
using EmprestaGame.API.Model;
using EmprestaGame.API.ReturnMessage;
using EmprestaGame.Business;
using EmprestaGame.Business.Contracts;
using EmprestaGame.Data.Context;
using EmprestaGame.Data.Repositories;
using Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace EmprestaGame.API.Filters
{
    public class AuthEmprestaGame : AuthorizeAttribute
    {
        private Message _mensagem;
        private readonly IBusinessBase<Usuario> _usuarioBusiness;
        private readonly IBusinessBase<Token> _tokenBusiness;
        private readonly EmprestaGameContext _context;

        public AuthEmprestaGame()
        {
            _context = new EmprestaGameContext();

            _usuarioBusiness = new BusinessBase<Usuario>(new RepositoryBase<Usuario>(_context));
            _tokenBusiness = new BusinessBase<Token>(new RepositoryBase<Token>(_context));
        }
        
        
        public override void OnAuthorization(HttpActionContext actionContext)
        {
           
            if ((actionContext.Request.Headers.Authorization == null)
                || string.IsNullOrWhiteSpace(actionContext.Request.Headers.Authorization.Scheme.Trim())
                || actionContext.Request.Headers.Authorization.Scheme.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Count() != 2)
            {
                _mensagem = ErrorMessages.AUTENTICACAO_INVALIDA;
                base.OnAuthorization(actionContext);
                return;
            }
            else
            {
                string usuario = actionContext.Request.Headers.Authorization.Scheme.Split('|')[0];
                string senhaToken = actionContext.Request.Headers.Authorization.Scheme.Split('|')[1];
                string ip = ((HttpContextWrapper)actionContext.Request.Properties["MS_HttpContext"]).Request.UserHostName;

                DateTime agora = DateTime.Now;
                string origem = actionContext.Request.RequestUri.AbsolutePath;

                if (origem.EndsWith("/login/logar", StringComparison.OrdinalIgnoreCase))
                {
                    //Autenticar por senha.
                    if (_usuarioBusiness.Count(x => x.Login.Equals(usuario) && x.Senha.Equals(senhaToken)) > 0)
                    {
                        //Renovar token, se existir.
                        Token tokenExistente = _tokenBusiness.GetItens(token => token.Login.Equals(usuario)).FirstOrDefault();
                        if (tokenExistente != null)
                        {
                            tokenExistente.IP = ip;
                            tokenExistente.Chave = Cripto.GeraToken(usuario, ip);
                            tokenExistente.Validade = DateTime.Now.AddMinutes(30);

                            _tokenBusiness.Update(tokenExistente);
                        }
                        else //Se não, criar novo token.
                        {
                            Token t = new Token()
                            {
                                IP = ip,
                                Login = usuario,
                                Chave = Cripto.GeraToken(usuario, ip),
                                Validade = DateTime.Now.AddMinutes(30)
                            };

                            _tokenBusiness.Add(t);
                        }
                    }
                    else
                    {
                        //Chamar esse metodo sempre que não for autorizado
                        _mensagem = ErrorMessages.USUARIO_OU_SENHA_INVALIDO;
                        base.OnAuthorization(actionContext);
                        return;
                    }
                }
                else
                {
                    //Autenticar por token.
                    if (_tokenBusiness.Count(token => token.Chave.Equals(senhaToken)) == 0)
                    {
                        //Chamar esse metodo sempre que não for autorizado
                        _mensagem = ErrorMessages.AUTENTICACAO_INVALIDA;
                        base.OnAuthorization(actionContext);
                        return;
                    }
                }
            }
        }

        //Metodo para tratar requisições não autorizadas
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var response =
                actionContext.Request.CreateResponse<ModelBase<object>>(HttpStatusCode.Unauthorized,
                              new ModelBase<object>()
                              {
                                  Mensagem = _mensagem,
                                  Model = null
                              });

            actionContext.Response = response;
        }
    }
}