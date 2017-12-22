using System.Collections.Generic;

namespace EmprestaGame.DTO
{
    public class EmprestimoDTO : DTOBase
    {
        public int idUsuario { get; set; }
        public UsuarioDTO Usuario { get; set; }

        public List<JogoDTO> ListaJogos { get; set; }

    }
}