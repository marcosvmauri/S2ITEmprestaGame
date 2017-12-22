using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.DTO
{
    public class UsuarioDTO : DTOBase
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        //public  ICollection<JogoDTO> ListaJogos { get; set; }
        //public  ICollection<EmprestimoDTO> ListaEmprestimo { get; set; }

    }
}