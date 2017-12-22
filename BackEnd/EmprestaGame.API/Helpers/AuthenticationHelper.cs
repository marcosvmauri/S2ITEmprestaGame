using EmprestaGame.Business;
using EmprestaGame.Business.Contracts;
using EmprestaGame.Data.Context;
using EmprestaGame.Data.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmprestaGame.API.Helpers
{
    public class AuthenticationHelper
    {
        private readonly IBusinessBase<Token> _tokenBusiness;
        private readonly EmprestaGameContext _context;

        public AuthenticationHelper()
        {
            _context = new EmprestaGameContext();
            _tokenBusiness = new BusinessBase<Token>(new RepositoryBase<Token>(_context));
        }

        public string GetToken(string login)
        {
            //Single() para garantir retorno de erro caso aconteça de existir mais de um token na tabela.
            return _tokenBusiness.GetItens(x => x.Login == login).Single().Chave;
        }

        public void RemoverToken(string login)
        {
            IEnumerable<Token> tokensExistente = _tokenBusiness.GetItens(x => x.Login == login);
            tokensExistente.ToList().ForEach(x =>
            {
                _tokenBusiness.Remove(x.Id);
            });
        }
    }
}