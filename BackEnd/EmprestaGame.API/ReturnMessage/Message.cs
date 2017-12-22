using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmprestaGame.API.ReturnMessage
{
    public class Message
    {
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string Mensagem { get; set; }
        public string Titulo { get; set; }
    }
}