using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Emprestimo : EntidadeBase
    {
        public virtual int idUsuario { get; set; }
        public virtual int idJogo { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Jogo Jogo { get; set; }

    }
}
