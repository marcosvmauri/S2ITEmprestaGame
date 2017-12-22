using EmprestaGame.Business.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmprestaGame.API.ReturnMessage
{
    public class WarningMessages
    {
        public static Message SISTEMA_EM_MANUTENCAO = new Message()
        {
            Tipo = EnumReturnCode.WARNING.GetEnumDescription(),
            Codigo = "W999",
            Titulo = "Aviso",
            Mensagem = "O sistema encontra-se em manutenção no momento. Contate o suporte ou tente novamente dentro de alguns instantes."
        };
    }
}