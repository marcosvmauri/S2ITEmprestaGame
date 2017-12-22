using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.Data.Repositories.Contracts
{
    public interface IJogoRepository : IRepositoryBase<Jogo>
    {

        IEnumerable<Jogo> MeusJogos(int IdUsuario);
        IEnumerable<Jogo> JogosDisponiveis(int IdUsuario);
        IEnumerable<Jogo> JogosEmprestados(int IdUsuario);
        IEnumerable<Jogo> JogosAdevolver(int IdUsuario);
    }
}
