using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.DTO
{
    class TokenDTO : DTOBase
    {
        public string Login { get; set; }
        public string Chave { get; set; }
        public string IP { get; set; }
        public DateTime Validade { get; set; }
    }
}
