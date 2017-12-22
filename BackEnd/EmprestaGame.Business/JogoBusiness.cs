using EmprestaGame.Business.Contracts;
using EmprestaGame.Data.Repositories.Contracts;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmprestaGame.Business
{
    public class JogoBusiness : BusinessBase<Jogo>, IJogoBusiness
    {
        private readonly IBusinessBase<Usuario> _usuarioBusiness;
        private readonly IJogoRepository _repository;

        public JogoBusiness(IJogoRepository repository, IBusinessBase<Usuario> usuarioBusiness) : base(repository)
        {
            _usuarioBusiness = usuarioBusiness;
            _repository = repository;
        }

        public List<Jogo> MeusJogos(string login)
        {
            Usuario usuario = getUsuario(login);

            var retorno = _repository.MeusJogos(usuario.Id);

            return retorno.ToList();
        }

        public List<Jogo> JogosDisponiveis(string login)
        {
            
            Usuario usuario = getUsuario(login);

            var retorno = _repository.JogosDisponiveis(usuario.Id);

            return retorno.ToList();
        }

        public List<Jogo> JogosEmprestados(string login)
        {
           
            Usuario usuario = getUsuario(login);

            var retorno = _repository.JogosEmprestados(usuario.Id);

            return retorno.ToList();
        }

        public List<Jogo> JogosAdevolver(string login)
        {
            
            Usuario usuario = getUsuario(login);

            var retorno = _repository.JogosAdevolver(usuario.Id);

            return retorno.ToList();
        }

        
        private Usuario getUsuario(string login)
        {
            return _usuarioBusiness.GetItens(x => x.Login.Equals(login)).Single();
        }



    }
}
