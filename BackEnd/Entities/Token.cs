using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Token : EntidadeBase
    {
        public string Login { get; set; }
        public string Chave { get; set; }
        public string IP { get; set; }
        public DateTime Validade { get; set; }
    }
}
