using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Jogo : EntidadeBase
    {
        public string Nome { get; set; }
        public string Console { get; set; }
        public int idUsuario { get; set; } 

        public virtual Usuario Usuario { get; set; }
        
        public virtual List<Emprestimo> ListaEmprestimo { get; set; }

    }
}

