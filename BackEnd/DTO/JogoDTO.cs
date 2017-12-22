using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.DTO
{

    public class JogoDTO : DTOBase
    {

        public string Nome { get; set; }

        public string Console { get; set; }

        public int idUsuario { get; set; }

        public UsuarioDTO Usuario { get; set; }

        public int idEmprestimo { get; set; }

        public EmprestimoDTO Emprestimo { get; set; }
    }
}


