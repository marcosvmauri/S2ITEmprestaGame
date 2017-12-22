using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.Business.Contracts
{
    public interface IJogoBusiness : IBusinessBase<Jogo>
    {
        List<Jogo> MeusJogos(string login);

        List<Jogo> JogosDisponiveis(string login);

        List<Jogo> JogosEmprestados(string login);

        List<Jogo> JogosAdevolver(string login);
    }
}
