using EmprestaGame.Business.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmprestaGame.API.ReturnMessage
{
    public class SuccessMessages
    {
        public static Message CONSULTA = new Message()
        {
            Tipo = EnumReturnCode.SUCCESS.GetEnumDescription(),
            Codigo = "S001",
            Titulo = "Aviso",
            Mensagem = "Consulta realizada com sucesso"
        };

        public static Message ALTERACAO = new Message()
        {
            Tipo = EnumReturnCode.SUCCESS.GetEnumDescription(),
            Codigo = "S002",
            Titulo = "Aviso",
            Mensagem = "Alteração realizada com sucesso"
        };

        public static Message CADASTRO = new Message()
        {
            Tipo = EnumReturnCode.SUCCESS.GetEnumDescription(),
            Codigo = "S003",
            Titulo = "Aviso",
            Mensagem = "Cadastro realizado com sucesso"
        };

        public static Message EXCLUSAO = new Message()
        {
            Tipo = EnumReturnCode.SUCCESS.GetEnumDescription(),
            Codigo = "S004",
            Titulo = "Aviso",
            Mensagem = "Registro excluido com sucesso"
        };

        public static Message EMPRESTIMO = new Message()
        {
            Tipo = EnumReturnCode.SUCCESS.GetEnumDescription(),
            Codigo = "S005",
            Titulo = "Aviso",
            Mensagem = "Jogo emprestado com sucesso"
        };

        public static Message DEVOLVIDO = new Message()
        {
            Tipo = EnumReturnCode.SUCCESS.GetEnumDescription(),
            Codigo = "S005",
            Titulo = "Aviso",
            Mensagem = "Jogo devolvido com sucesso"
        };



    }
}