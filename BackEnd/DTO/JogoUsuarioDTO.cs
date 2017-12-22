using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.DTO
{
    
    public class JogoUsuarioDTO : DTOBase
    {

        public string Nome { get; set; }
        public string Console { get; set; }
        public int idUsuario { get; set; }

        public virtual UsuarioDTO Usuario { get; set; }

        public virtual List<EmprestimoDTO> ListaEmprestimo { get; set; }

    }
}


