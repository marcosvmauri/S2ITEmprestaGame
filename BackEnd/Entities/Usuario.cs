using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Jogo> ListaJogos { get; set; }
        public virtual ICollection<Emprestimo> ListaEmprestimo { get; set; }

    }
}